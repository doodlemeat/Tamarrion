using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Tamarrion {
	public class Player_AttackBoss : StateMachineBehaviour {

		//public ParticleSystem particleSystem;

		//public CombatText FloatingText;
		//public float AttackTime, RotateTime;
		//private float m_time_attacked;
		//private bool m_attacked, m_stopped;

		//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		//{
		//	m_attacked = false;
		//	m_stopped = false;
		//	m_time_attacked = 0.0f;
		//}

		//public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		//{
		//	Debug.Log("exiting attack state");
		//	if (m_time_attacked >= AttackTime && !m_attacked)
		//		PerformAttack();
		//	base.OnStateExit(animator, stateInfo, layerIndex);
		//}

		//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		//{
		//	m_time_attacked += Time.deltaTime * Player.player.GetComponent<PlayerStats>().m_stat["attack_speed"];
		//	if (m_time_attacked < AttackTime - RotateTime && !m_stopped)
		//	{
		//		Player.player.GetComponent<PlayerMovement>().SetControllable(false);
		//		Player.player.GetComponent<PlayerMovement>().SetMoveable(false);
		//		m_stopped = true;
		//	}

		//	if (m_time_attacked >= AttackTime - RotateTime && m_stopped)
		//	{
		//		Player.player.GetComponent<PlayerMovement>().SetControllable(true);
		//		m_stopped = false;
		//	}

		//	if (m_time_attacked >= AttackTime && !m_attacked)
		//		PerformAttack();
		//}

		//void PerformAttack()
		//{
		//	if (!FirstBoss.instance)
		//		return;

		//	Player.player.GetComponent<PlayerMovement>().SetMoveable(true);
		//	Transform m_player = Player.player.gameObject.GetComponent<Transform>(),
		//	m_boss = FirstBoss.instance.gameObject.GetComponent<Transform>();
		//	CombatStats m_player_stats = m_player.GetComponent<CombatStats>();

		//	bool distance = Vector3.Distance(m_player.position, m_boss.position) < m_player_stats.m_stat["attack_range"];
		//	bool angle = Vector3.Angle(m_player.forward, m_boss.position - m_player.position) < 67.5f;

		//	int attacks = m_player_stats.GetMultistrike() ? 2 : 1;
		//	List<AttackInfo> attackInfo = new List<AttackInfo>();

		//	for (int i = 0; i < attacks; i++)
		//	{
		//		bool crit = m_player_stats.GetCrit();
		//		float base_damage = m_player_stats.m_stat["attack_damage"];
		//		float damage = Random.Range(base_damage, base_damage * 1.5f) * (crit ? 2.0f : 1.0f);
		//		attackInfo.Add(new AttackInfo(damage, crit));

		//		if (onAttack != null)
		//		{
		//			onAttack(distance, angle, attackInfo[attackInfo.Count - 1]);
		//		}
		//	}

		//	if (distance && angle)
		//	{
		//		/*float damage = 0.0f;
		//		bool crit = false;
		//		int attacks = m_player_stats.GetMultistrike() ? 2 : 1;

		//		for (int i = 0; i < attacks; i++)
		//		{
		//			crit = m_player_stats.GetCrit();
		//			float base_damage = m_player_stats.m_stat["attack_damage"];
		//			damage = Random.Range(base_damage, base_damage * 1.5f) * (crit ? 2.0f : 1.0f);
		//			FirstBoss.instance.GetComponent<Enemy_Stats>().DealDamage(damage, crit);
		//		}*/

		//		foreach (AttackInfo ai in attackInfo)
		//		{
		//			FirstBoss.instance.GetComponent<Enemy_Stats>().DealDamage(ai._damage, ai._crit);
		//			if (onHit != null)
		//			{
		//				onHit(ai);
		//			}
		//		}


		//		if (particleSystem)
		//			Instantiate(particleSystem, m_boss.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
		//	}
		//	m_attacked = true;
		//}

		//public class AttackInfo
		//{
		//	public float _damage;
		//	public bool _crit;

		//	public AttackInfo(float damage, bool crit)
		//	{
		//		_damage = damage;
		//		_crit = crit;
		//	}
		//}
	}
}