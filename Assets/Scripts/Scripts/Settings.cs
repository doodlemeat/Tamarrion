using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    public bool Inverted_Xaxis = false;
    public bool Inverted_Yaxis = false;
    public bool TutorialOn = true;
    public bool TutorialForceOff = false;

    [System.Serializable]
    class SettingsStruct
    {
        public bool Inverted_Xaxis = false;
        public bool Inverted_Yaxis = false;
        public bool TutorialOn = true;
        public bool TutorialForceOff = false;
    }

    void Update()
    {
        if (Application.isEditor)
        {
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(KeyCode.T))
            {
                SetTutorialOn(!TutorialOn);
                Debug.Log("tutorial: " + TutorialOn);
            }
        }
    }

    void Awake()
    {
        instance = this;
        Load();
    }

    void OnDisable()
    {
        Save();
    }

    void Save()
    {
        BinaryFormatter bff = new BinaryFormatter();
        FileStream ffs = File.Create(Application.persistentDataPath + "/settings.dat");

        SettingsStruct invTest = new SettingsStruct();
        invTest.Inverted_Xaxis = Inverted_Xaxis;
        invTest.Inverted_Yaxis = Inverted_Yaxis;
        invTest.TutorialOn = TutorialOn;
        invTest.TutorialForceOff = TutorialForceOff;

        bff.Serialize(ffs, invTest);
        ffs.Close();
    }

    void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/settings.dat"))
            return;

        BinaryFormatter bff = new BinaryFormatter();
        FileStream ffs = File.Open(Application.persistentDataPath + "/settings.dat", FileMode.Open);

        SettingsStruct invTest = (SettingsStruct)bff.Deserialize(ffs);
        ffs.Close();

        Inverted_Xaxis = invTest.Inverted_Xaxis;
        Inverted_Yaxis = invTest.Inverted_Yaxis;
        TutorialOn = invTest.TutorialOn;
        TutorialForceOff = invTest.TutorialForceOff;
    }

    public void SetInvertedXaxis(bool p_value)
    {
        Inverted_Xaxis = p_value;
    }

    public void SetInvertedYaxis(bool p_value)
    {
        Inverted_Yaxis = p_value;
    }

    public void SetTutorialOn(bool p_value)
    {
        TutorialOn = p_value;
        Save();
    }
}
