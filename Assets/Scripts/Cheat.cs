using UnityEngine;

// Cheat system enables you to teleport to boss locations
// Only works when playing from editor
// Extend this class further when neccessary

namespace Tamarrion {
    public class Cheat : MyMonoBehaviour {
        [SerializeField]
        private string firstBossTeleportKey = "f1";

        [SerializeField]
        private string secondBossTeleportKey = "f1";

        [SerializeField]
        private string thirdBossTeleportKey = "f3";

        public Transform firstBossTeleportPosition;
        public Transform secondBossTeleportPosition;
        public Transform thirdBossTeleportPosition;

        void Update() {
            if (Application.isEditor) {
                if (Input.GetKeyDown(firstBossTeleportKey.ToLower())) {
                    Player.player.transform.position = firstBossTeleportPosition.position;
                }

                if (Input.GetKeyDown(secondBossTeleportKey.ToLower())) {
                    Player.player.transform.position = secondBossTeleportPosition.position;
                }

                if (Input.GetKeyDown(thirdBossTeleportKey.ToLower())) {
                    Player.player.transform.position = thirdBossTeleportPosition.position;
                }
            }
        }
    }
}
