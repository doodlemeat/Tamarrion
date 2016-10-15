using UnityEngine;
using System.Collections;

namespace Tamarrion {
    public class ForcePusher : MonoBehaviour {
        public static ForcePusher instance;
        public GameObject BoxObj;
        public GameObject SphereObj;
        public GameObject CylinderObj;
        public bool DebugShowMeshes = false;

        public enum Shape {
            Box,
            Sphere,
            Cylinder,
        }

        void Awake() {
            instance = this;
        }

        public void SendForceFromObject(GameObject p_obj, Vector3 p_force, float p_lifetime, Shape p_shape, Vector3 p_scale = new Vector3(), Vector3 p_position_offset = new Vector3(), bool p_child_of_obj = false, Vector3 p_rotation_adjust = new Vector3(), bool p_rotation_follow_obj = true) {
            if (!p_obj || (p_shape == Shape.Box && !BoxObj) || (p_shape == Shape.Sphere && !SphereObj) || (p_shape == Shape.Cylinder && !CylinderObj))
                return;

            Vector3 targetPos = p_obj.transform.position + p_position_offset;

            GameObject inst = null;
            if (p_shape == Shape.Box)
                inst = (GameObject)Instantiate(BoxObj, targetPos, BoxObj.transform.rotation);
            else if (p_shape == Shape.Sphere)
                inst = (GameObject)Instantiate(SphereObj, targetPos, SphereObj.transform.rotation);
            else if (p_shape == Shape.Cylinder)
                inst = (GameObject)Instantiate(CylinderObj, targetPos, CylinderObj.transform.rotation);

            if (p_rotation_follow_obj)
                inst.transform.rotation = p_obj.transform.rotation;
            inst.transform.Rotate(p_rotation_adjust.x, p_rotation_adjust.y, p_rotation_adjust.z, Space.Self);
            inst.transform.localScale = p_scale;

            if (p_child_of_obj)
                inst.transform.SetParent(p_obj.transform);

            //ignore player collision
            Physics.IgnoreCollision(Player.player.gameObject.GetComponent<CharacterController>(), inst.GetComponent<Collider>());
            foreach (Collider col in Player.player.gameObject.GetComponentsInChildren<Collider>()) {
                Physics.IgnoreCollision(col, inst.GetComponent<Collider>());
            }

            //ignore enemy collision
            foreach (Enemy_Base en in Enemy_List.Enemies) {
                foreach (Collider col in en.gameObject.GetComponentsInChildren<Collider>()) {
                    //Debug.Log(en.name + ", " + col.name);
                    Physics.IgnoreCollision(col, inst.GetComponent<Collider>());
                }
            }

            if (DebugShowMeshes)
                inst.GetComponent<MeshRenderer>().enabled = true;

            //apply velocity
            inst.GetComponent<Rigidbody>().velocity = (inst.transform.forward * p_force.x) + (inst.transform.up * p_force.y) + (inst.transform.right * p_force.z);
            inst.GetComponent<RemoveObjectAtStart>().Delay = p_lifetime;
        }

        public void SendForceFromPosition(Vector3 p_pos, Vector3 p_force, float p_lifetime, Shape p_shape, Vector3 p_scale = new Vector3(), Quaternion p_rotation = new Quaternion()) {
            if ((p_shape == Shape.Box && !BoxObj) || (p_shape == Shape.Sphere && !SphereObj) || (p_shape == Shape.Cylinder && !CylinderObj))
                return;

            if (p_scale == Vector3.zero)
                p_scale = new Vector3(1, 1, 1);

            GameObject inst = null;
            if (p_shape == Shape.Box)
                inst = (GameObject)Instantiate(BoxObj, p_pos, BoxObj.transform.rotation);
            else if (p_shape == Shape.Sphere)
                inst = (GameObject)Instantiate(SphereObj, p_pos, SphereObj.transform.rotation);
            else if (p_shape == Shape.Cylinder)
                inst = (GameObject)Instantiate(CylinderObj, p_pos, CylinderObj.transform.rotation);

            //inst.transform.Rotate(p_rotation.x, p_rotation.y, p_rotation.z, Space.Self);
            inst.transform.localScale = p_scale;

            //ignore player collision
            Physics.IgnoreCollision(Player.player.gameObject.GetComponent<CharacterController>(), inst.GetComponent<Collider>());
            foreach (Collider col in Player.player.gameObject.GetComponentsInChildren<Collider>()) {
                Physics.IgnoreCollision(col, inst.GetComponent<Collider>());
            }

            //ignore boss collision
            foreach (Enemy_Base en in Enemy_List.Enemies) {
                foreach (Collider col in en.gameObject.GetComponentsInChildren<Collider>()) {
                    Physics.IgnoreCollision(col, inst.GetComponent<Collider>());
                }
            }

            if (!DebugShowMeshes)
                inst.GetComponent<MeshRenderer>().enabled = false;

            //apply velocity
            inst.GetComponent<Rigidbody>().velocity = (inst.transform.forward * p_force.x) + (inst.transform.up * p_force.y) + (inst.transform.right * p_force.z);
            inst.GetComponent<RemoveObjectAtStart>().Delay = p_lifetime;
        }
    }
}