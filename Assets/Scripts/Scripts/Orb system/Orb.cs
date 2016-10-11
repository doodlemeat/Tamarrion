using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public abstract class Orb : MonoBehaviour {
		public float _elevateSpeed = 0.2f;
		public float _elevateHeight = 2.0f;
		public float _rotationSpeed = 1.5f;

		protected PlayerStats _playerStats;
		protected bool _triggered = false;

		float _baseHeight;

		protected virtual void OnTriggerEnter (Collider other) {
			_playerStats = other.GetComponent<PlayerStats> ();
			if ( _playerStats )
				_triggered = true;
			else
				_triggered = false;
		}

		public virtual void Start () {
			_baseHeight = transform.position.y;
		}

		public virtual void Update () {
			float height = Mathf.Sin (Time.time * _elevateSpeed) * _elevateHeight;
			Vector3 newPosition = transform.position;
			newPosition.y = _baseHeight + height;
			transform.position = newPosition;
			transform.Rotate (Vector3.up, _rotationSpeed);
		}
	}
}