using UnityEngine;
using System.Collections;

namespace Tamarrion {
    [RequireComponent(typeof(CameraController))]
    public class CameraCollision : MonoBehaviour {
        public static CameraCollision Instance;

        SimpleCollision simpleCollision = new SimpleCollision();

        void Awake() {
            Instance = this;
        }

        ViewCollision GetCollisionAlgorithm(string algorithm) {
            switch (algorithm) {
                case "Simple":
                    return simpleCollision;
            }

            return null;
        }

        public void Process(Vector3 cameraTarget, Vector3 targetHead, Vector3 direction, float distance, out float collisionDistance) {
            // Choose collision algorithm
            ViewCollision viewCollision = GetCollisionAlgorithm("Simple");

            // Calculate view distance
            Vector3 currentTargetPosition = targetHead;
            collisionDistance = viewCollision.Process(currentTargetPosition, direction, distance);
        }
    }
}