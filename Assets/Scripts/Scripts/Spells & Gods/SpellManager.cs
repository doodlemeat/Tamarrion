using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tamarrion {
    public class SpellManager : MonoBehaviour {
        public static SpellManager Instance;

        public enum SpellType {
            HOLY,
            SUPPORT,
            MELEE,
            MAGIC,
            DEFENSE
        }

        [System.Serializable]
        class SpellData {
            public int[] selected = new int[4];
        }

        public const int SpellSlotCount = 4;

        private GameObject playerObject;
        private Player playerScript;
        public List<GameObject> spells = new List<GameObject>();
        public List<GameObject> passiveSpells = new List<GameObject>();
        public int[] selectedSpells = new int[SpellSlotCount];
        public GameObject[] equippedSpells = new GameObject[SpellSlotCount];
        public List<int> selectedPassiveSpells = new List<int>();
        //private SpellBase castingSpell = null;

        private bool Loaded = false;

        void Awake() {
            Instance = this;

            for (int i = 0; i < SpellSlotCount; ++i) {
                selectedSpells[i] = -1;
                equippedSpells[i] = null;
            }
            //Load();
        }

        void OnDisable() {
            Save();
        }

        void Start() {
            /*playerScript = Player.player.GetComponent<Player>();
            playerObject = playerScript.gameObject;
            for (int i = 0; i < SpellSlotCount; ++i)
            {
                selectSpellByIndex(i, selectedSpells[i], false);
            }

            lockSpells();

            Loaded = true;*/
        }

        void Update() {
            /*if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(KeyCode.P))
            {
                for (int i = 0; i < SpellSlotCount; ++i)
                {
                    selectedSpells[i] = -1;
                    PlayerPrefs.SetInt("playerSpell_" + i, -1);
                }
            }*/
        }

        public bool GetLoaded() {
            return Loaded;
        }

        public List<GameObject> getSpells() {
            return spells;
        }

        public void selectSpellByIndex(int p_slot, int p_index, bool p_setPlayerPrefs = true) {
            if (p_slot < 0 || p_slot >= SpellSlotCount)
                return;

            if (p_index < 0 || p_index >= spells.Count)
                return;

            for (int i = 0; i < SpellSlotCount; ++i) {
                if (selectedSpells[i] == p_index) {
                    selectedSpells[i] = -1;
                    if (p_setPlayerPrefs) {
                        //PlayerPrefs.SetInt("playerSpell_" + i, -1);
                        //Debug.Log("Setting playerSpell_" + i + " to index " + p_index);
                    }
                    break;
                }
            }

            selectedSpells[p_slot] = p_index;
            if (p_setPlayerPrefs) {
                //PlayerPrefs.SetInt("playerSpell_" + p_slot, p_index);
                //Debug.Log("Setting playerSpell_" + p_slot + " to index " + p_index);
            }
        }

        public void selectSpellByName(string p_name, int p_slot) {
            for (int i = 0; i < spells.Count; ++i) {
                if (spells[i].name == p_name)
                    selectSpellByIndex(p_slot, i);
            }
        }

        public void selectPassiveSpell(string name) {
            for (int i = 0; i < passiveSpells.Count; ++i) {
                if (name == passiveSpells[i].name) {
                    selectedPassiveSpells.Add(i);
                }
            }
        }

        public void lockSpells() {
            //clear old spells
            equippedSpells = new GameObject[4];

            //add selected active spells
            for (int slot = 0; slot < SpellSlotCount; ++slot) {
                equippedSpells[slot] = null;
                if (selectedSpells[slot] != -1) {
                    //Debug.Log("instansiating " + spells[selectedSpells[slot]].name + " index: " + selectedSpells[slot]);
                    equippedSpells[slot] = Instantiate(spells[selectedSpells[slot]]);
                    equippedSpells[slot].transform.SetParent(playerObject.transform);
                }
            }

            // add selected passive spells
            //foreach (int index in selectedPassiveSpells)
            //{
            //GameObject passiveSpellObject = Instantiate(passiveSpells[index]);
            //passiveSpellObject.transform.SetParent(playerScript.transform);
            //playerScript.passiveSpells.Add(passiveSpellObject.GetComponent<PassiveSpellBase>());
            //}
        }

        public int GetSpellIndexInSlot(int p_slot) {
            if (p_slot < 0 || p_slot >= SpellSlotCount)
                return -1;

            return selectedSpells[p_slot];
        }

        public GameObject GetSpellInSlot(int p_slot) {
            if (p_slot < 0 || p_slot >= SpellSlotCount) {
                //Debug.Log("outside spell slot range.");
                return null;
            }

            if (selectedSpells[p_slot] == -1) {
                //Debug.Log("no spell in slot.");
                return null;
            }

            return equippedSpells[p_slot];
        }

        void Save() {
            BinaryFormatter bff = new BinaryFormatter();
            FileStream ffs = File.Create(Application.persistentDataPath + "/spells.dat");

            SpellData invTest = new SpellData();
            invTest.selected = selectedSpells;

            bff.Serialize(ffs, invTest);
            ffs.Close();
        }

        void Load() {
            Debug.Log("SpellManager:Load");
            if (!File.Exists(Application.persistentDataPath + "/spells.dat"))
                return;

            BinaryFormatter bff = new BinaryFormatter();
            FileStream ffs = File.Open(Application.persistentDataPath + "/spells.dat", FileMode.Open);

            SpellData invTest = (SpellData)bff.Deserialize(ffs);
            ffs.Close();

            selectedSpells = invTest.selected;
        }
    }
}