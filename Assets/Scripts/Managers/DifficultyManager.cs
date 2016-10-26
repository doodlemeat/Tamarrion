using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tamarrion {
	public class DifficultyManager : MyMonoBehaviour {
		public static Difficulty current;

		[System.Serializable]
		class DifficultyStruct {
			public Difficulty diff = Difficulty.Normal;
		}

		void Awake() {
			current = Difficulty.Normal;
			Load();
		}

		void OnDisable() {
			Save();
		}

		void Save() {
			//Debug.Log("saving difficulty: " + Current_difficulty);

			BinaryFormatter bff = new BinaryFormatter();
			FileStream ffs = File.Create(Application.persistentDataPath + "/difficulty.dat");

			DifficultyStruct invTest = new DifficultyStruct();
			invTest.diff = current;

			bff.Serialize(ffs, invTest);
			ffs.Close();
		}

		void Load() {
			if (!File.Exists(Application.persistentDataPath + "/difficulty.dat"))
				return;

			BinaryFormatter bff = new BinaryFormatter();
			FileStream ffs = File.Open(Application.persistentDataPath + "/difficulty.dat", FileMode.Open);

			DifficultyStruct invTest = (DifficultyStruct)bff.Deserialize(ffs);
			ffs.Close();

			current = invTest.diff;

			//Debug.Log("loaded difficulty: " + Current_difficulty);
		}
	}
}
