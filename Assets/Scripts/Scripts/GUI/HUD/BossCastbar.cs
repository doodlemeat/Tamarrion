using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossCastbar : MonoBehaviour
{
    public static BossCastbar castbar = null;
    public float FadeOutTime = 0.5f;
    /*public Color ColorHoly = new Color(1, 0.9f, 0.6f, 1);
    public Color ColorMagic = new Color(0.6f, 0.7f, 1, 1);
    public Color ColorSupport = new Color(0.8f, 0.6f, 1, 1);
    public Color ColorDefense = new Color(0.6f, 1, 0.6f, 1);
    public Color ColorMelee = new Color(1, 0.5f, 0.5f, 1);*/
    
    private Image progressBar = null;
    private Enemy_SkillManager skill_manager = null;
	private Enemy_SkillManager[] skill_managers = new Enemy_SkillManager[2];
    private float FadeCurrent = 0;
    private bool StoppedUsingSkill = true;

    void Awake() {
        castbar = this;
    }

    void Start() {
        skill_managers[0] = Nihteana.instance.GetComponent<Enemy_SkillManager>();
        skill_managers[1] = Valac.instance.GetComponent<Enemy_SkillManager>();
        //skill_manager = skill_managers[0];
        progressBar = GetComponentInChildren<Image>();
        //GetComponent<CanvasGroup>().alpha = 1;
    }

    void Update() {
        if (skill_manager == null) {
            GetComponent<CanvasGroup>().alpha = 0;
            return;
        }

        //Simoncode: Removed this as we no longer add non-castbar skills to the skillmanager
        //if (skill_manager.UsingSkill() && !skill_manager.GetShowCastbar())
        //{
        //    //GetComponent<CanvasGroup>().alpha = 1;
        //}

        //Simoncode: Moved this up to get the progress before showing it on the bar
        if (skill_manager.UsingSkill())
        {
            StoppedUsingSkill = false;
            progressBar.fillAmount = skill_manager.GetProgress();
        }
        else if (!StoppedUsingSkill)
        {
            StoppedUsingSkill = true;
            FadeCurrent = FadeOutTime;
        }
        /*else if (skill_manager2.UsingSkill()) {
        StoppedUsingSkill = false;
        //GetComponent<CanvasGroup>().alpha = 1;
        progressBar.fillAmount = skill_manager2.GetProgress();
        }*/

        if (StoppedUsingSkill)
        {
            progressBar.fillAmount = 1;
            if (FadeCurrent > 0)
            {
                FadeCurrent -= Time.deltaTime;
                if (FadeCurrent < 0)
                {
                    FadeCurrent = 0;
                    progressBar.fillAmount = 0;
                }
                GetComponent<CanvasGroup>().alpha = FadeCurrent / FadeOutTime;
            }
        }
    }

    public void OnSpellcast(string spell) {
        if (skill_manager == null) {
            return;
        }
        //if (!spell)
        //    return;
        GetComponentInChildren<Text>().text = spell;
        if (skill_manager.GetShowCastbar())
            GetComponent<CanvasGroup>().alpha = 1;
		//if (skill_manager2.GetShowCastbar())
		//	GetComponent<CanvasGroup>().alpha = 1;

        //Simoncode: Reset the progressbar when we start a new skill
        progressBar.fillAmount = 0;
        StoppedUsingSkill = false;
        /*if (spell._Type == SpellManager.SpellType.HOLY)
            progressBar.color = ColorHoly;
        else if (spell._Type == SpellManager.SpellType.MAGIC)
            progressBar.color = ColorMagic;
        else if (spell._Type == SpellManager.SpellType.SUPPORT)
            progressBar.color = ColorSupport;
        else if (spell._Type == SpellManager.SpellType.DEFENSE)
            progressBar.color = ColorDefense;
        else if (spell._Type == SpellManager.SpellType.MELEE)
            progressBar.color = ColorMelee;*/
    }
    public void SetSkillManager(string p_name) {
        //Debug.Log(p_name);
        if (p_name == "Valac") {
            skill_manager = skill_managers[1];
        }
        else {
            skill_manager = skill_managers[0];
        }
    }
    public void TurnInvisible() {
        GetComponent<CanvasGroup>().alpha = 0;
    }
}