using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Selectable DefaultSelected;
    public Menu PreviousMenu;
    public bool IsCovered = false;
    public bool BackEnabled = true;

    private Animator m_xAnimator;
    private CanvasGroup m_xCanvasGroup;

    public bool IsOpen
    {
        get { return m_xAnimator.GetBool("IsOpen"); }
        set { m_xAnimator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        m_xAnimator = GetComponent<Animator>();
        m_xCanvasGroup = GetComponent<CanvasGroup>();

        RectTransform TransRect = GetComponent<RectTransform>();
        TransRect.offsetMax = TransRect.offsetMin = new Vector2(0, 0);
    }

    public void Update()
    {
        if (!m_xAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            m_xCanvasGroup.blocksRaycasts = m_xCanvasGroup.interactable = false;
        }
        else
        {
            m_xCanvasGroup.blocksRaycasts = m_xCanvasGroup.interactable = true;
        }
    }

    public void Activate()
    {
        IsOpen = true;

        if (DefaultSelected)
            DefaultSelected.Select();
    }

    public void Cover(bool p_value)
    {
        IsCovered = p_value;
    }

    public void SetBackEnabled(bool p_value)
    {
        BackEnabled = p_value;
    }
}