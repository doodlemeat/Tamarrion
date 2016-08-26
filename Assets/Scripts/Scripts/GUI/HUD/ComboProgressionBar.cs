using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComboProgressionBar : MonoBehaviour
{
    bool BarActive = false;
    Animator _animator;
    Image _image;
    string GodTypeString = "";

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _image = gameObject.GetComponent<Image>();
        if (_image)
            _image.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (BarActive)
        {
            _image.fillAmount = GodManager.Instance.GetPercentDone();
        }

        if (!BarActive && GodManager.Instance.CurrentGod)
        {
            BarActive = true;

            if (GodManager.Instance.CurrentGod.element == FSSkillElement.FS_Elem_Holy)
                GodTypeString = "Holy";
            else if (GodManager.Instance.CurrentGod.element == FSSkillElement.FS_Elem_Magic)
                GodTypeString = "Magic";
            else if (GodManager.Instance.CurrentGod.element == FSSkillElement.FS_Elem_War)
                GodTypeString = "War";
            else if (GodManager.Instance.CurrentGod.element == FSSkillElement.FS_Elem_Defense)
                GodTypeString = "Defense";
            else if (GodManager.Instance.CurrentGod.element == FSSkillElement.FS_Elem_Nature)
                GodTypeString = "Nature";

            if (GodTypeString != "" && _animator)
                _animator.SetBool(GodTypeString, true);
            if (_image)
                _image.color = new Color(1, 1, 1, 1);
        }
        else if (BarActive && !GodManager.Instance.CurrentGod)
        {
            BarActive = false;
            if (GodTypeString != "" && _animator)
                _animator.SetBool(GodTypeString, false);
            if (_image)
                _image.color = new Color(1, 1, 1, 0);
        }
    }
}
