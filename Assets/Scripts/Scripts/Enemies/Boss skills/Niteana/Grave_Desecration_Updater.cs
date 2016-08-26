using UnityEngine;
using System.Collections;

public class Grave_Desecration_Updater : Base_EnemySkill_Telegraph {

    public GameObject Hand;
    public int number_of_hands = 0;
    public float slow_amount = 0.5f, slow_time = 4.0f;
    public Texture slow_texture;

    protected override void CheckHit() {
        base.CheckHit();
        if (Hand != null) {
            for (int i = 0; i < number_of_hands; i++) {
                Vector3 position = transform.position;
                Vector3 offest = Random.insideUnitCircle;
                position.x += offest.x * Size;
                position.y -= 0.02f;
                position.z += offest.y * Size;
                GameObject tmp = Instantiate(Hand);
                tmp.transform.position = position;
                tmp.transform.LookAt(desecration_lookatthis.instance);
                //tmp.transform.SetParent(transform);
            }
        }
        if (ForcePusher.instance)
            ForcePusher.instance.SendForceFromPosition(gameObject.transform.position, new Vector3(0, 10, 0), 0.15f, ForcePusher.Shape.Cylinder, new Vector3(4, 0.05f, 4));
    }
    protected override void OnHitEffect() {
        m_player.GetComponent<CombatStats>().Remove_Modifier("desecration_slow");
        m_player.GetComponent<CombatStats>().Add_Modifier("desecration_slow", "movement_speed", 0.0f, slow_amount);
        BuffManager.player_buffs.AddBuff("desecration_slow", Player.player.gameObject, slow_time, slow_texture);
    }
}