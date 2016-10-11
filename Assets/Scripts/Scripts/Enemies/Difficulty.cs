using UnityEngine;
using System.Collections;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Tamarrion {
	public class Difficulty : MonoBehaviour {

		public enum difficulty {
			beginner,
			normal,
			brutal
		};
		public static difficulty Current_difficulty;

		[System.Serializable]
		class DifficultyStruct {
			public difficulty diff = difficulty.normal;
		}

		void Awake () {
			Current_difficulty = difficulty.normal;
			Load ();
		}

		void Start () {
			//Debug.Log("Initialize difficulty");
			//Current_difficulty = difficulty.normal;
			//Load();

			//if (FirstBoss.instance)
			//    FirstBoss.instance.GetComponent<Enemy_Stats>().InitializeSpecificStats();

			//Debug.Log("difficulty is " + Current_difficulty);
		}

		void OnDisable () {
			Save ();
		}

		void Save () {
			//Debug.Log("saving difficulty: " + Current_difficulty);

			BinaryFormatter bff = new BinaryFormatter ();
			FileStream ffs = File.Create (Application.persistentDataPath + "/difficulty.dat");

			DifficultyStruct invTest = new DifficultyStruct ();
			invTest.diff = Current_difficulty;

			bff.Serialize (ffs, invTest);
			ffs.Close ();
		}

		void Load () {
			if ( !File.Exists (Application.persistentDataPath + "/difficulty.dat") )
				return;

			BinaryFormatter bff = new BinaryFormatter ();
			FileStream ffs = File.Open (Application.persistentDataPath + "/difficulty.dat", FileMode.Open);

			DifficultyStruct invTest = (DifficultyStruct)bff.Deserialize (ffs);
			ffs.Close ();

			Current_difficulty = invTest.diff;

			//Debug.Log("loaded difficulty: " + Current_difficulty);
		}
	}
}