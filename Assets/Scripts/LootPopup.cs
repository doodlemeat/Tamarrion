using UnityEngine;
using UnityEngine.UI;

namespace Tamarrion {
	public class LootPopup : MyMonoBehaviour {
		Animator animator;
		Image image;
		RawImage itemIcon;
		Text itemName;
		float timer = 0.0f;
		BaseItem item = null;

		public float duration = 3.0f;

		void Awake() {
			animator = GetComponent<Animator> ();
			image = GetComponent<Image> ();
			image.enabled = false;
			itemIcon = GetComponentInChildren<RawImage> ();
			itemIcon.enabled = false;
			itemName = GetComponentInChildren<Text> ();
			itemName.enabled = false;

			AddListener<LootEvent> (OnLoot);
		}

		void OnDestroy() {
			RemoveListener<LootEvent> (OnLoot);
		}

		void OnLoot(LootEvent e) {
			item = e.item;
			animator.SetBool ("ShowPopup", true);
			image.enabled = true;
			timer = 0.0f;
		}

		void Update() {
			if(image.enabled) {
				timer += Time.deltaTime;

				if(timer >= duration) {
					image.enabled = false;
					animator.SetBool ("ShowPopup", false);
					timer = 0.0f;
					itemIcon.enabled = false;
					itemName.enabled = false;
				}
			}
		}

		public void PopupReady() {
			itemIcon.enabled = true;
			itemName.enabled = true;
			if ( item ) {
				itemIcon.texture = item.itemIcon;
				itemName.text = item.itemName;
			}
		}
	}
}
