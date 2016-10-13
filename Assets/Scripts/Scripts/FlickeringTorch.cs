using UnityEngine;
namespace Tamarrion {
	public class FlickeringTorch : MonoBehaviour {
		Light lightObject = null;
		//float random = 0.0f;
		public bool active = true;
		public float DeathLightDuration = 2;

		public Rigidbody torchRigidBody;

		ParticleSystem particleSystemObject;
		public AudioSource startSound;
		public MeshRenderer lightMesh;
		bool _fallof = false;
		float _wantedRange;
		float _currentRange;
		float _wantedStartSpeed;
		float _currentStartSpeed;
		float lightIntensity;

		private bool Dying = false;
		private float DeathLightDurationCurrent;
		private float EmissionRateStandard;

		void Start () {
			//random = Random.Range(0.0f, 65535.0f);
			lightObject = GetComponentInChildren<Light> ();
			particleSystemObject = GetComponentInChildren<ParticleSystem> ();
			EmissionRateStandard = particleSystemObject.emissionRate;
			_currentRange = _wantedRange = lightObject.range;
			lightIntensity = lightObject.intensity;
			_currentStartSpeed = _wantedStartSpeed = particleSystemObject.startSpeed;

			SetRigidbodyActivated (false);
			SetMeshVisible (false);
		}

		void SetMeshVisible (bool p_visible = true) {
			if ( lightMesh )
				lightMesh.enabled = p_visible;
		}

		void SetRigidbodyActivated (bool p_active = true) {
			if ( !torchRigidBody )
				return;

			torchRigidBody.detectCollisions = p_active;
			torchRigidBody.useGravity = p_active;
		}

		void Update () {
			if ( !lightObject )
				return;

			lightObject.range = _currentRange;
			particleSystemObject.startSpeed = _currentStartSpeed;

			if ( !Dying ) {
				//if (active)
				//{
				//	if (lightObject)
				//	{
				//		if (!lightObject.enabled)
				//		{
				//			lightObject.enabled = true;
				//		}
				//	}

				//	if (!particleSystemObject.isPlaying)
				//	{
				//		particleSystemObject.Play();
				//	}
				//}
				//else
				//{
				//	if (lightObject)
				//	{
				//		if (lightObject.enabled)
				//		{
				//			lightObject.enabled = false;
				//		}
				//	}

				//	if (particleSystemObject.isPlaying)
				//	{
				//		particleSystemObject.Stop();
				//	}
				//}
			}
			else if ( DeathLightDurationCurrent > 0 ) {
				DeathLightDurationCurrent -= Time.deltaTime;
				if ( DeathLightDurationCurrent <= 0 ) {
					Destroy (lightObject.gameObject);
					lightObject = null;
					DeathLightDurationCurrent = 0;
					particleSystemObject.Stop ();
				}

				float PercentageDone = 1 - (DeathLightDurationCurrent / DeathLightDuration);
				particleSystemObject.emissionRate = Mathf.Lerp (EmissionRateStandard, 0, PercentageDone);
				if ( lightObject )
					lightObject.intensity = Mathf.Lerp (lightIntensity, 0, PercentageDone);
			}

			if ( _fallof ) {
				bool rangeFinished = false;
				bool startSpeedFinished = false;

				if ( _currentRange > _wantedRange ) {
					_currentRange -= 0.28f;
				}
				else {
					rangeFinished = true;
				}

				if ( _currentStartSpeed > _wantedStartSpeed ) {
					_currentStartSpeed -= 0.1f;
				}
				else {
					startSpeedFinished = true;
				}

				if ( rangeFinished && startSpeedFinished ) {
					_fallof = false;
				}
			}
		}

		public void toggleOn () {
			PlayStartSound ();
			active = true;
			_fallof = true;

			SetMeshVisible ();
		}

		void PlayStartSound () {
			if ( startSound && !startSound.isPlaying )
				startSound.Play ();
		}

		public void toggleOff () {
			active = false;
			_fallof = false;
		}

		public void PutOut () {
			Dying = true;
			DeathLightDurationCurrent = DeathLightDuration;
			SetRigidbodyActivated ();
			SetMeshVisible (false);
		}
	}
}