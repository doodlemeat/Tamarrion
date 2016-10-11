using UnityEngine;
using System.Collections.Generic;
namespace Tamarrion {
	public class ValacStartSequence : BaseEncounterSequence {
		bool Started;
		bool _cinematicEnded = false;
		float _introEndTimeout = 1.0f;
		float _introEndTimer = 0.0f;

		public float animationSpeed = 0.5f;
		public float bossActivationDelay = 10;
		public float MusicStartOffset = 10;
		public GameObject animationDoor;
		public GameObject flyingDoor;
		public GameObject preFinishedCollision;
		public Animation lowerCoffinAnimation;
		public CameraPathAnimator introCinematic;
		public List<MausoleumAlcoveLight> alcoveLights = new List<MausoleumAlcoveLight> ();
		public List<GameObject> ObjectsToActivateOnSequenceStart = new List<GameObject> ();

		void Start () {
			Started = false;
			lowerCoffinAnimation.Play ();
			lowerCoffinAnimation.wrapMode = WrapMode.ClampForever;
			foreach ( AnimationState state in lowerCoffinAnimation ) {
				state.speed = 0;
			}
			flyingDoor.SetActive (false);
		}

		void SetAlcoveLightsActive (bool p_active = true) {
			foreach ( MausoleumAlcoveLight light in alcoveLights ) {
				light.SetEnabled (p_active);
			}
		}

		override public void StartSequence () {
			base.StartSequence ();
			Started = true;
			StartAnimation ();
			CameraController.instance.ForceLockOnTarget (Valac.instance.transform);

			PlayerAttack.instance.AddAttackBlock ("valac_start_sequence");
			Evade.instance.AddEvadeBlock ("valac_sequence");
			SetAlcoveLightsActive ();
			OrbSystem.Instance.SetActive (true);
			ActivateObjects ();
		}

		void ActivateObjects () {
			foreach ( GameObject go in ObjectsToActivateOnSequenceStart ) {
				go.SetActive (true);
			}
		}

		override public void Update () {
			if ( Started && bossActivationDelay > 0 ) {
				bossActivationDelay -= Time.deltaTime;
				if ( bossActivationDelay <= 0 ) {
					bossActivationDelay = 0;
					ActivateBoss ();
				}
			}

			if ( Started && sequenceComplete == false && introCinematic.isPlaying == false ) {
				_introEndTimer += Time.deltaTime;
				if ( _introEndTimer >= _introEndTimeout ) {
					CameraController cameraController = Camera.main.GetComponent<CameraController> ();
					cameraController.enabled = true;

					if ( PlayerMovement.instance )
						PlayerMovement.instance.RemoveMoveBlock ("valac_start_sequence");
					if ( Evade.instance )
						Evade.instance.RemoveEvadeBlock ("valac_sequence");

					if ( FSSkillUser.instance )
						FSSkillUser.instance.RemoveSkillBlock ("valac_start_sequence");

					CameraController.instance.RemoveForceLock ();

					sequenceComplete = true;

					PlayerAttack.instance.RemoveAttackBlock ("valac_start_sequence");
				}
			}

			//for performance:
			//if (sequenceComplete)
			//    gameObject.SetActive(false);
		}

		bool AnyCinematicComplete () {
			if ( lowerCoffinAnimation != null ) {
				foreach ( AnimationState state in lowerCoffinAnimation ) {
					if ( state.time * state.speed >= state.length )
						return true;
				}
			}
			return false;
		}

		void StartAnimation () {
			lowerCoffinAnimation.Play ();
			if ( TutorialProgression.instance && Settings.instance.TutorialOn )
				TutorialProgression.instance.ActivateDoorCollider ();
			BossMusic.instance.StartMusic (MusicStartOffset);
			foreach ( AnimationState state in lowerCoffinAnimation ) {
				state.speed = animationSpeed;
			}

			if ( introCinematic != null ) {
				CameraController cameraController = Camera.main.GetComponent<CameraController> ();
				cameraController.enabled = false;

				introCinematic.Play ();

				PlayerMovement playerMovement = Player.player.GetComponent<PlayerMovement> ();
				playerMovement.AddMoveBlock ("valac_start_sequence");

				if ( FSSkillUser.instance )
					FSSkillUser.instance.AddSkillBlock ("valac_start_sequence");
			}
		}

		void ActivateBoss () {
			if ( preFinishedCollision != null )
				Destroy (preFinishedCollision);
			flyingDoor.SetActive (true);
			//Destroy(flyingDoor.transform.parent.gameObject);
			flyingDoor.transform.SetParent (null);
			animationDoor.SetActive (false);
			foreach ( Collider col in Valac.instance.gameObject.GetComponentsInChildren<Collider> () ) {
				Physics.IgnoreCollision (col, flyingDoor.GetComponent<Collider> ());
			}

			if ( ForcePusher.instance ) {
				Vector3 forceSpawnOffset = new Vector3 (1, 0, -1.2f);
				ForcePusher.instance.SendForceFromPosition (flyingDoor.transform.position + forceSpawnOffset, new Vector3 (20, 1, 0), 2.0f, ForcePusher.Shape.Box);
			}
			if ( Valac.instance )
				Valac.instance.ActivateBoss ();

			FightStats.StartTimer ();
		}

		public void OnIntroCinematicFinish () {
			_cinematicEnded = true;
		}
	}
}