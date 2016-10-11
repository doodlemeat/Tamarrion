using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class Encounter : MonoBehaviour {
		bool Started = false;
		public bool Disabled = false;
		public string progressPreStateName = "";
		public string progressPostStateName = "";
		public List<Collider> BlockingCollidersDuringEncounter;
		public GameObject[] magic_barrier;
		[Tooltip ("An AudioSource needs to be added to this Object for the BossMusic to work")]
		public BossMusic BossMusic;
		public BaseEncounterSequence sequence;

		void Start () {
			SetBlockCollidersBlockStatus (false);
		}

		//temporary test
		//void Update()
		//{
		//    if (Input.GetKeyDown(KeyCode.L))
		//        SetEncounterAsFailed();
		//}

		public BossCastbar castbar;
		public string castbar_name;

		public void StartEncounter () //This is called from the StartEncounterColliderTrigger
		{
			if ( Started || Disabled )
				return;

			Started = true;

			if ( Player.player )
				Player.player.progressStateName = progressPreStateName;

			if ( sequence != null )
				sequence.StartSequence ();

			if ( castbar != null )
				castbar.SetSkillManager (castbar_name);

			SetBlockCollidersBlockStatus (true);
		}

		public bool GetStarted () {
			return Started;
		}

		public void SetEncounterAsCompelte () {
			Debug.Log ("encounter complete");
			Started = false;
			Disabled = true;
			SetBlockCollidersBlockStatus (false);
			castbar.TurnInvisible ();
		}

		public void SetEncounterAsFailed () {
			Started = false;
			castbar.TurnInvisible ();
			SetBlockCollidersBlockStatus (false);
		}

		private void SetBlockCollidersBlockStatus (bool p_blockingStatus) {
			foreach ( Collider col in BlockingCollidersDuringEncounter ) {
				col.enabled = p_blockingStatus;
			}

			foreach ( GameObject m in magic_barrier )
				m.SetActive (p_blockingStatus);
		}
	}
}