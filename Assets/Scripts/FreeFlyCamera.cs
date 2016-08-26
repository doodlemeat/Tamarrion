using UnityEngine;

namespace Tamarrion {
	public class FreeFlyCamera : MyMonoBehaviour {
		new Camera camera;
		public float moveSpeed = 1.0f;
		public float sensitivity = 1.0f;

		void Awake () {
			camera = GetComponent<Camera> ();
		}

		void LateUpdate () {
			Vector3 direction = Vector3.zero;
			Vector3 movement = Vector3.zero;

			if(Input.GetKey(KeyCode.W)) {
				direction.z = 1;
			} else if(Input.GetKey(KeyCode.S)) {
				direction.z = -1;
			}

			if(Input.GetKey(KeyCode.A)) {
				direction.x = -1;
			} else if(Input.GetKey(KeyCode.D)) {
				direction.x = 1;
			}

			movement = camera.transform.rotation * direction;
			movement *= Time.deltaTime * moveSpeed;

			float rotX = transform.eulerAngles.y + Input.GetAxisRaw ("Mouse X") * sensitivity;
			float rotY = transform.eulerAngles.x - Input.GetAxisRaw ("Mouse Y") * sensitivity;

			transform.localEulerAngles = new Vector3 (rotY, rotX, 0);

			transform.position += movement;
		}
	}
}