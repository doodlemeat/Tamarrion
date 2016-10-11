using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class Spell_Fast : SpellBase {
		public GameObject projectile;
		public GameObject CastParticleSys;
		public float speed;
		public float damageMin;
		public float damageMax;

		public override void use () {
			base.use ();

			bool crit = _playerStats.GetCrit ();
			float base_damage = _playerStats.m_stat["damage"] + _playerStats.m_stat["magical"];
			float damage = Random.Range (base_damage, base_damage * 1.5f) * (crit ? _playerStats.m_stat["crit_damage"] : 1.0f);

			PlayerAnimationEventHandler.Instance.OnArcane ();
			GameObject projectileObject = (GameObject)Instantiate (projectile, Valac.instance.transform.position + new Vector3 (0, 8, 0), Player.player.transform.rotation);
			Projectile projectileScript = projectileObject.GetComponent<Projectile> ();
			projectileScript.speed = speed;
			projectileScript.damage = damage + Random.Range (damageMin, damageMax);
			projectileScript.crit = crit;
			//projectileScript.target = FirstBoss.instance.transform.FindChild("Spell target").gameObject;
		}

		public override void cast () {
			base.cast ();
			if ( CastParticleSys ) {
				Transform CastTransform = Player.player.LeftHand ? Player.player.LeftHand.transform : Player.player.transform;
				Vector3 Offset = new Vector3 (0, !Player.player.LeftHand ? 1.1f : 0, 0);
				GameObject partSys = (GameObject)Instantiate (CastParticleSys, CastTransform.position + Offset, Player.player.transform.rotation);
				partSys.transform.SetParent (CastTransform);
			}
		}
	}
}