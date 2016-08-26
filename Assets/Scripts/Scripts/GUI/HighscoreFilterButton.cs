using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreFilterButton : MonoBehaviour
{
	public int _difficulty = -1;

	void Start()
	{
	}

	public void DeSelect()
	{
        gameObject.GetComponent<RawImage>().color = HighscoreFilters.Instance.InactiveColor;
        gameObject.GetComponentInChildren<Text>().color = HighscoreFilters.Instance.InactiveTextColor;
	}

	public void Select()
	{
        gameObject.GetComponent<RawImage>().color = HighscoreFilters.Instance.ActiveColor;
        gameObject.GetComponentInChildren<Text>().color = HighscoreFilters.Instance.ActiveTextColor;
		HighscoreLoader.Instance.applyFilters(_difficulty);
		/*if (FiltersOn)
			InventoryMenu.instance.ApplyFilters(Slot);
		else
			InventoryMenu.instance.GetComponent<InventoryMenu>().RemoveFilters();

		StartCoroutine("ResetScrollbar");*/
	}
}