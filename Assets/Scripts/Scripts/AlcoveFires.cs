using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
	public class AlcoveFires : MonoBehaviour {
		public static AlcoveFires instance;
		public List<GameObject> Fires;
		public List<GameObject> DamageColliders;
		public float DamageDelay = 1;
		public float DamageInverval = 0.1f;
		public List<float> DamageAmount = new List<float>();

		private bool FiresActive = false;
		private float DamageDelayCurrent;
		private float DamageInvervalCurrent;
		private float BackupDamage = 5;

		void Awake() {
			instance = this;
			Deactivate();
		}

		void Update() {
			if (FiresActive) {
				if (DamageDelayCurrent > 0) {
					DamageDelayCurrent -= Time.deltaTime;
					if (DamageDelayCurrent <= 0)
						DamageDelayCurrent = 0;
				}
				else {
					DamageInvervalCurrent -= Time.deltaTime;
					if (DamageInvervalCurrent <= 0) {
						DamageInvervalCurrent = DamageInverval;
						foreach (GameObject obj in DamageColliders) {
							if (obj.GetComponent<BoxCollider>().bounds.Contains(Player.player.transform.position)) {
								float FinalAmount = BackupDamage;
								if (DamageAmount.Count - 1 >= (int)DifficultyManager.current)
									FinalAmount = DamageAmount[(int)DifficultyManager.current];

								PlayerStats.instance.DealDamage(FinalAmount);
							}
						}
					}
				}
			}
		}

		public void Activate() {
			DamageDelayCurrent = DamageDelay;
			DamageInvervalCurrent = DamageInverval;
			FiresActive = true;
			foreach (GameObject obj in Fires) {
				obj.SetActive(true);
			}
		}

		public void Deactivate() {
			FiresActive = false;
			foreach (GameObject obj in Fires) {
				obj.SetActive(false);
			}
		}
	}
}
