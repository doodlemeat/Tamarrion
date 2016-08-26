using UnityEngine;
using System.Collections;

public class Player_ComboAttack : StateMachineBehaviour
{
    public float move_time = 0.3f;
    public float move_speed_modifier = 2;
    public float force_delay = 0.2f;

    private PlayerAttack m_player_attack;
    private float m_time_attacked;
    private bool m_attacked, m_stopped, m_qued;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_player_attack = Player.player.GetComponent<PlayerAttack>();
        m_time_attacked = 0.0f;
        m_attacked = false;
        m_stopped = true;
        m_qued = false;

        animator.SetTrigger("Attacking");
        PlayerMovement.instance.AddMoveBlock("attack");

        animator.SetBool("Attack", false);
        animator.SetBool("QuedAttack1", false);
        animator.SetBool("QuedAttack2", false);

        m_player_attack.StartAttack(force_delay);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_time_attacked += Time.deltaTime;
        if (m_time_attacked > 0.25f * m_player_attack.SpeedModifier && PlayerAttack.instance.AttackEnabled() && Input.GetAxis("Attack") > 0 && !m_qued)
        {
            m_player_attack.combo++;
            animator.SetBool("QuedAttack" + Random.Range(1, 3), true);
            m_qued = true;
        }

        if (m_stopped && m_time_attacked >= m_player_attack.AttackTime - m_player_attack.RotateTime)
        {
            m_stopped = false;
            PlayerMovement.instance.RemoveMoveBlock("attack");
        }
        if (!m_attacked && m_time_attacked >= m_player_attack.AttackTime)
        {
            m_attacked = true;
            m_player_attack.PerformAttack("physical");
        }
        if (m_time_attacked < move_time && !Evade.instance.IsEvading())
            PlayerMovement.instance._controller.Move(Player.player.transform.forward * Time.deltaTime * move_speed_modifier);
    }
}