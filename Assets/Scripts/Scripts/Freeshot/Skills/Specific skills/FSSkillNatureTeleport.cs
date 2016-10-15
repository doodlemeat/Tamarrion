using UnityEngine;
using System.Collections.Generic;

namespace Tamarrion {
    public class FSSkillNatureTeleport : FSSkillArea {
        List<GameObject> teleportObjectInstances = new List<GameObject>();

        void Start() {
            FSObjectNatureTeleport.onTeleport += OnTeleport;
        }

        public override void ApplySkillEffect() {
            if (areaObject) {
                GameObject obj = (GameObject)Instantiate(areaObject, spawnPosition, spawnRotation);
                FSObjectArea area = obj.GetComponent<FSObjectArea>();
                if (base.duration > 0)
                    area.SetDuration(base.duration);
                //if (base.shape == FSSkillShape.FS_Shape_Circle)
                //    area.SetSphereCollisionRadius(base.shapeSize * 0.5f);
                //if (base.shape == FSSkillShape.FS_Shape_Box)
                //    area.SetSphereCollisionRadius(base.shapeSize * 0.5f); //TO-DO: fix to box

                teleportObjectInstances.Add(obj);
                if (teleportObjectInstances.Count > 2)
                    RemoveEarliestTeleportInstance();

                ConnectTeleportsIfPossible();
            }
        }

        void ConnectTeleportsIfPossible() {
            if (teleportObjectInstances.Count == 2) {
                ConnectTwoTeleports(teleportObjectInstances[0].GetComponent<FSObjectNatureTeleport>(),
                    teleportObjectInstances[1].GetComponent<FSObjectNatureTeleport>());
            }
        }

        void ConnectTwoTeleports(FSObjectNatureTeleport p_first, FSObjectNatureTeleport p_second) {
            p_first.SetOtherTeleport(p_second);
            p_second.SetOtherTeleport(p_first);
        }

        void RemoveEarliestTeleportInstance() {
            RemoveTeleportGameObject(teleportObjectInstances[0]);
            teleportObjectInstances.RemoveAt(0);
        }

        void RemoveTeleportGameObject(GameObject p_teleport) {
            p_teleport.GetComponent<FSObjectNatureTeleport>().RemoveTeleport();
        }

        public override void SkillEnd() {

        }

        void OnTeleport() {
            foreach (GameObject teleObj in teleportObjectInstances) {
                RemoveTeleportGameObject(teleObj);
            }
            teleportObjectInstances.Clear();
        }
    }
}