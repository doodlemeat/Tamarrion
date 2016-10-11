using UnityEngine;
using System.Collections.Generic;
namespace Tamarrion {
	public class TutorialProgression : MonoBehaviour {
		public static TutorialProgression instance;
		public Collider doorCollider;
		public List<GameObject> Doors;
		public float animationSpeed = 0.75f;
		public float PlayerControlDelay = 2.0f;
		public Transform SkipPlayerPos;
		public Transform SkipCameraPos;
		public AudioSource doorOpenAudioSource;

		void Awake () {
			instance = this;
		}

		public enum TutorialMessageType {
			DashInfo,
			AttackInfo,
			DoorsOpen,
			ControlInfo,
			SpellInfo,
			Count,
		}

		class TutorialStage {
			public TutorialMessageType messageType = TutorialMessageType.Count;
			public bool hasBeenActivated = false;

			public TutorialStage (TutorialMessageType p_messageType) {
				messageType = p_messageType;
			}
		}

		TutorialStage currentStage;
		List<TutorialStage> tutorialStages = new List<TutorialStage> ();

		void Start () {
			//if (doorCollider && doorCollider.GetComponentInChildren<ParticleSystem>())
			//    doorCollider.GetComponentInChildren<ParticleSystem>().Stop();

			//if (doorCollider)
			//{
			//    Physics.IgnoreCollision(Player.player.gameObject.GetComponent<CharacterController>(), doorCollider.GetComponent<Collider>());
			//}

			if ( !Settings.instance.TutorialOn )
				SkipTutorial ();
			else
				doorCollider.enabled = false;

			Player.player.InMenu = true;

			tutorialStages.Add (new TutorialStage (TutorialMessageType.AttackInfo));
			tutorialStages.Add (new TutorialStage (TutorialMessageType.DashInfo));
			tutorialStages.Add (new TutorialStage (TutorialMessageType.ControlInfo));
			tutorialStages.Add (new TutorialStage (TutorialMessageType.SpellInfo));
		}

		TutorialStage GetStageByMessageType (TutorialMessageType p_messageType) {
			foreach ( TutorialStage stage in tutorialStages ) {
				if ( stage.messageType == p_messageType )
					return stage;
			}

			return null;
		}

		void SkipTutorial () {
			tutorialStages.Clear ();
			ActivateDoorCollider ();

			if ( SkipPlayerPos ) {
				//Player.player.gameObject.transform.position = SkipPlayerPos.position;
				//Player.player.gameObject.transform.rotation = SkipPlayerPos.rotation;
			}
			if ( SkipCameraPos ) {
				CameraController.instance.gameObject.transform.position = SkipCameraPos.position;
				CameraController.instance.gameObject.transform.rotation = SkipCameraPos.rotation;
			}

			PlayerStats.instance.m_stat["health"] = PlayerStats.instance.m_stat["max_health"];
			OrbSystem.Instance.DestroyAllOrbs ();
		}

		void Update () {
			if ( PlayerControlDelay > 0 ) {
				PlayerControlDelay -= Time.deltaTime;
				if ( PlayerControlDelay <= 0 ) {
					PlayerControlDelay = 0;
					Player.player.InMenu = false;
				}
			}

			//To-do (tomas 2015-12-16): For improved performance, replace this update-logic with events from onAttack and onEvade.
			if ( currentStage != null ) {
				if ( GetStageByMessageType (TutorialMessageType.DashInfo) != null
					&& currentStage == GetStageByMessageType (TutorialMessageType.DashInfo)
					&& Evade.instance.IsEvading () ) {
					CancelCurrentStage ();
				}

				if ( GetStageByMessageType (TutorialMessageType.AttackInfo) != null
					&& currentStage == GetStageByMessageType (TutorialMessageType.AttackInfo)
					&& Player.player.gameObject.GetComponentInChildren<Animator> ().GetBool ("Attacking") ) {
					CancelCurrentStage ();
				}
				if ( GetStageByMessageType (TutorialMessageType.ControlInfo) != null
					&& currentStage == GetStageByMessageType (TutorialMessageType.ControlInfo)
					&& Player.player.gameObject.GetComponentInChildren<Animator> ().GetBool ("MovingLeft") ) {
					CancelCurrentStage ();
				}
				if ( GetStageByMessageType (TutorialMessageType.SpellInfo) != null
					&& currentStage == GetStageByMessageType (TutorialMessageType.SpellInfo)
					&& Player.player.gameObject.GetComponentInChildren<Animator> ().GetBool ("Cast") ) {
					CancelCurrentStage ();
				}
			}
		}

		void CancelCurrentStage () {
			currentStage = null;
			if ( TutorialPopup.instance )
				TutorialPopup.instance.Disable ();
		}

		public void Progress (TutorialMessageType p_messageType) {
			if ( !Settings.instance.TutorialOn )
				return;

			if ( p_messageType == TutorialMessageType.DashInfo || p_messageType == TutorialMessageType.AttackInfo || p_messageType == TutorialMessageType.ControlInfo || p_messageType == TutorialMessageType.SpellInfo ) {
				if ( GetStageByMessageType (p_messageType) != null && GetStageByMessageType (p_messageType).hasBeenActivated == false ) {
					currentStage = GetStageByMessageType (p_messageType);
					currentStage.hasBeenActivated = true;
					if ( TutorialPopup.instance )
						TutorialPopup.instance.ShowHelp (p_messageType);
				}
			}
			else if ( p_messageType == TutorialMessageType.DoorsOpen ) {
				foreach ( GameObject obj in Doors ) {
					if ( obj && obj.GetComponent<Animation> () )
						obj.GetComponent<Animation> ().Play ();
				}
				if ( doorOpenAudioSource )
					doorOpenAudioSource.Play ();
			}
		}

		public void ActivateDoorCollider () {
			if ( !doorCollider )
				return;

			doorCollider.enabled = true;

			//Physics.IgnoreCollision(Player.player.gameObject.GetComponent<CharacterController>(), doorCollider.GetComponent<Collider>(), false);

			if ( !Settings.instance.TutorialOn )
				return;

			foreach ( GameObject obj in Doors ) {
				if ( !obj || !obj.GetComponent<Animation> () )
					continue;

				Animation anim = obj.GetComponent<Animation> ();
				anim["Opening"].speed = -1 * animationSpeed;
				anim["Opening"].time = anim["Opening"].length;
				anim.Play ();
			}
		}
	}
}