using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class BossActivationCoffin : MonoBehaviour {
		public float animationSpeed = 0.5f;
		public float bossActivationDelay = 10;
		public GameObject animationDoor;
		public GameObject flyingDoor;
		public GameObject preFinishedCollision;
		public Transform BossSpawnPos;
		public float MusicStartOffset = 10;
		public Animation lowerCoffinAnimation;
		private bool Started = false;
		private float ActivationDistance;
		public CameraPathAnimator _introCinematic;

		bool _cinematicEnded = false;
		float _introEndTimeout = 1.0f;
		float _introEndTimer = 0.0f;

		void Start () {
			Debug.Log (name);
			lowerCoffinAnimation.Play ();
			ActivationDistance = GetComponent<SphereCollider> ().radius;
			lowerCoffinAnimation.wrapMode = WrapMode.ClampForever;
			flyingDoor.SetActive (false);
		}

		void OnCollisionEnter (Collision collision) {
			//Debug.Log("collision enter!");
			if ( !Started && collision.gameObject != Player.player.gameObject )
				return;

			Started = true;
			lowerCoffinAnimation.Play ();
			CameraController.instance.ForceLockOnTarget (Valac.instance.transform);
		}

		void Update () {
			if ( !Started && lowerCoffinAnimation["Take 001"].speed > 0 ) {
				foreach ( AnimationState state in lowerCoffinAnimation ) {
					state.speed = 0;
				}
			}
			if ( !Started && Vector3.Distance (Player.player.gameObject.transform.position, gameObject.transform.position) < ActivationDistance ) {
				StartAnimation ();
			}

			if ( Started && bossActivationDelay > 0 ) {
				bossActivationDelay -= Time.deltaTime;
				if ( bossActivationDelay <= 0 ) {
					bossActivationDelay = 0;
					ActivateBoss ();
				}
			}

			if ( _cinematicEnded ) {
				_introEndTimer += Time.deltaTime;
				if ( _introEndTimer >= _introEndTimeout ) {
					CameraController cameraController = Camera.main.GetComponent<CameraController> ();
					cameraController.enabled = true;

					PlayerMovement playerMovement = Player.player.GetComponent<PlayerMovement> ();
					playerMovement.RemoveMoveBlock ("boss_activation_coffin");

					_cinematicEnded = false;

					CameraController.instance.RemoveForceLock ();
				}
			}
		}

		void ActivateBoss () {
			Destroy (preFinishedCollision);
			flyingDoor.SetActive (true);
			Destroy (flyingDoor.transform.parent.gameObject);
			flyingDoor.transform.SetParent (null);
			animationDoor.SetActive (false);
			foreach ( Collider col in Valac.instance.gameObject.GetComponentsInChildren<Collider> () ) {
				Physics.IgnoreCollision (col, flyingDoor.GetComponent<Collider> ());
			}

			Valac.instance.gameObject.transform.position = BossSpawnPos.position;

			if ( ForcePusher.instance )
				ForcePusher.instance.SendForceFromPosition (flyingDoor.transform.position + new Vector3 (0, 0.5f, -2), new Vector3 (15, 5, 0), 0.2f, ForcePusher.Shape.Box);
			if ( Valac.instance )
				Valac.instance.ActivateBoss ();

			FightStats.StartTimer ();
		}

		public void StartAnimation () {
			Started = true;
			if ( TutorialProgression.instance && Settings.instance.TutorialOn )
				TutorialProgression.instance.ActivateDoorCollider ();
			BossMusic.instance.StartMusic (MusicStartOffset);
			foreach ( AnimationState state in lowerCoffinAnimation ) {
				state.speed = animationSpeed;
			}

			if ( _introCinematic ) {
				CameraController cameraController = Camera.main.GetComponent<CameraController> ();
				cameraController.enabled = false;

				_introCinematic.Play ();

				PlayerMovement playerMovement = Player.player.GetComponent<PlayerMovement> ();
				playerMovement.AddMoveBlock ("boss_activation_coffin");
			}
		}

		public void OnIntroCinematicFinish () {
			Debug.Log ("OnIntroCinematicFinish");
			_cinematicEnded = true;
		}
	}
}