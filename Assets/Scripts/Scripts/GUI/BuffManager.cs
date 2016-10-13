using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Tamarrion {
    public class BuffManager : MonoBehaviour {
        public static BuffManager player_buffs, boss_buffs;
        public Base_buff buff_prefab;
        private List<Base_buff> m_buffs = new List<Base_buff>();
        public bool player = false;

        void Awake() {
            //Debug.Log("player? " + player);
            if (player)
                player_buffs = this;
            else
                boss_buffs = this;
        }

        void Update() {
            for (int i = 0; i < m_buffs.Count; i++) {
                float time_left = m_buffs[i].GetTimeLeft();
                if (time_left <= 0.0f) {
                    m_buffs[i].BuffEnded();
                    m_buffs.Remove(m_buffs[i]);
                    break;
                }
                else {
                    SetPosition(m_buffs[i], time_left, i);
                }
            }
        }

        public void AddBuff(string p_name, GameObject p_target, float p_duration, Texture p_texture) {
            foreach (Base_buff b in m_buffs) {
                if (p_name.CompareTo(b.buff_name) == 0) {
                    b.Update_buff(p_duration);
                    return;
                }
            }
            buff_prefab.buff_name = p_name;
            buff_prefab.target = p_target;
            buff_prefab.active_time = p_duration;
            buff_prefab.GetComponent<RawImage>().texture = p_texture;
            Base_buff instance = Instantiate(buff_prefab);
            instance.transform.SetParent(gameObject.transform);
            RectTransform instance_rect = instance.GetComponent<RectTransform>();
            instance_rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            /*RectTransform rect = instance.GetComponent<RectTransform>();
            SetPosition(rect, 5);*/
            SetPosition(instance, 1.0f, m_buffs.Count);
            m_buffs.Add(instance);
        }
        private void SetPosition(Base_buff p_buff, float p_position, int p_index) {
            RectTransform buff_manager_rect = gameObject.GetComponent<RectTransform>(),
                buff_rect = p_buff.GetComponent<RectTransform>();
            float size = buff_manager_rect.sizeDelta.x - buff_manager_rect.sizeDelta.y;
            //Debug.Log(size);
            buff_rect.anchoredPosition = buff_manager_rect.anchoredPosition;
            //buff_rect.anchoredPosition = new Vector2(60.0f, 0.0f);// +1 and -1
            buff_rect.anchoredPosition = new Vector2(p_index * buff_manager_rect.sizeDelta.y/*size * p_position*/ - (size / 2.0f), /*p_index * (size / 14.0f)*/0.0f);// +1 and -1
            buff_rect.sizeDelta = new Vector2(-size, 0.0f);// -1/2 on both
                                                           //p_rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}