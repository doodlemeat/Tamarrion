using UnityEngine;
using System.Collections;
namespace Tamarrion {
	public class NihteanaSequence : BaseEncounterSequence {
		public Enemy_Base[] altars;

		public override void Update () {
			if ( !sequence_started || sequence_ended )
				return;

			//Debug.Log("sequence update");

			if ( portal_opened ) {
				if ( !close_portal ) {
					time_portal_open += Time.deltaTime;
					if ( time_portal_open >= portal_time_opened ) {
						close_portal = true;
					}
				}
				else if ( close_portal && !portal_closed ) {
					time_portal_closed += Time.deltaTime;
					gate.transform.localPosition += gate_close_vector * Time.deltaTime;
					if ( time_portal_closed >= portal_close_time ) {
						gate.transform.localPosition = gate_start_position;
						time_portal_closed = portal_close_time;
						portal_closed = true;
					}
					//Debug.Log(1 - (time_portal_closed / portal_close_time));
					//Portal.material.SetFloat("_ClippingSlider", 1 - (time_portal_closed / portal_close_time));
				}
				time_niht_moved += Time.deltaTime;
				Nihteana.instance.transform.position += move_vector * Time.deltaTime;
				Nihteana.instance.GetComponentInChildren<Animator> ().SetFloat ("Speed", 1);
				Nihteana.instance.GetComponentInChildren<Animator> ().SetBool ("Move Fast", true);
				if ( time_niht_moved >= Niht_move_time ) {
					Nihteana.instance.GetComponentInChildren<Animator> ().SetFloat ("Speed", 0);
					Nihteana.instance.GetComponentInChildren<Animator> ().SetBool ("Move Fast", false);
					Nihteana.instance.transform.position = End_position;
					sequence_ended = true;

					if ( boss && boss.GetComponent<Nihteana> () )
						boss.GetComponent<Nihteana> ().Active = true;// .SetActive(true);

					foreach ( Enemy_Base a in altars )
						a.Active = true;

					Nihteana.instance.GetComponent<Enemy_Stats> ().Add_Modifier ("invulnerable", "damage_reduction", 1, 1);
				}
			}
			else if ( effect_played && !portal_opened ) {
				gateStart.SetActive (false);
				gate.SetActive (true);
				portal_opened = true;
				//time_portal_opened += Time.deltaTime;
				//gate.transform.localPosition += gate_open_vector * Time.deltaTime;
				//if (time_portal_opened >= portal_open_time) {
				//gate.transform.localPosition = gate_end_position;
				//time_portal_opened = portal_open_time;
				//portal_opened = true;
				//}
				//Debug.Log(time_portal_opened / portal_open_time);
				//Portal.material.SetFloat("_ClippingSlider", time_portal_opened / portal_open_time);
			}
			else if ( color_swiched && !effect_played ) {
				/*if (!Particle_instansiated) {
					Particle_instansiated = true;
					ParticleSystem tmp = (ParticleSystem)Instantiate(Effect);
					tmp.transform.SetParent(Portal.transform);
					tmp.transform.localPosition = new Vector3(0, -1, 3);
				}*/
				if ( !effect_started ) {
					effect_started = true;
					effect.SetActive (true);
				}
				time_effect_played += Time.deltaTime;
				if ( time_effect_played >= effect_play_time ) {
					time_effect_played = effect_play_time;
					effect_played = true;
				}
			}
			else {
				time_color_swiched += Time.deltaTime;
				if ( time_color_swiched >= color_swich_time ) {
					time_color_swiched = color_swich_time;
					color_swiched = true;
				}
				//Debug.Log(time_color_swiched / color_swich_time);
				Portal.material.SetFloat ("_EmissiveColorSlider", time_color_swiched / color_swich_time);
			}
		}

		public MeshRenderer Portal = null;
		//public ParticleSystem Effect;
		//private bool Particle_instansiated = false;
		public GameObject effect = null, gate = null, gateStart = null;
		private Vector3 move_vector = Vector3.zero, gate_start_position = Vector3.zero, gate_open_vector = Vector3.zero, gate_close_vector = Vector3.zero;
		public Vector3 End_position = Vector3.zero, gate_end_position = Vector3.zero;
		public float color_swich_time = 0, portal_open_time = 0, portal_time_opened = 0, portal_close_time = 0, Niht_move_time = 0, effect_play_time = 0;
		private float time_color_swiched = 0, time_portal_opened = 0, time_portal_open = 0, time_portal_closed = 0, time_niht_moved = 0, time_effect_played = 0;
		private bool sequence_started = false, sequence_ended = false, color_swiched = false, effect_played = false, effect_started = false, portal_opened = false, close_portal = false, portal_closed = false;

		public override void StartSequence () {
			base.StartSequence ();
			//Debug.Log("Start Niht sequence");
			sequence_started = true;
			gate_start_position = gate.transform.localPosition;
			gate_open_vector = gate_end_position - gate_start_position;
			gate_close_vector = gate_start_position - gate_end_position;
			gate_open_vector *= 1 / portal_open_time;
			gate_close_vector *= 1 / portal_close_time;
			move_vector = End_position - Nihteana.instance.transform.position;
			move_vector *= 1 / Niht_move_time;
		}
	}
}