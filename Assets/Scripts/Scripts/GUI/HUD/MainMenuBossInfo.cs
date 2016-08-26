using UnityEngine;
using UnityEngine.UI;

public class MainMenuBossInfo : MonoBehaviour
{
    public static MainMenuBossInfo instance;
    public Text title;
    public Text description;

    void Awake()
    {
        instance = this;
    }

    public void SetTitleText(string p_newTitle)
    {
        if (!title)
            return;

        title.text = p_newTitle;
    }

    public void SetDescriptionText(string p_newDescription)
    {
        if (!description)
            return;

        description.text = p_newDescription;
    }
}
