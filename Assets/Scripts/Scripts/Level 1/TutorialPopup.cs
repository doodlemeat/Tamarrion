using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialPopup : MonoBehaviour
{
    public static TutorialPopup instance;
    public Texture dashButtonTexture;
    public Texture attackButtonTexture;
	public Texture moveButtonTexture;
	public Texture spellButtonTexture;
    public float RemoveTimer = 20;
    public float FadeOutTimer = 1;
    private float RemoveTimerCurrent;
    private float FadeOutTimerCurrent;
    private bool FadeOut = false;

    private Text tutorialText;
    private RawImage tutorialButtonImage;
	private RawImage tutorialBG;

    private Color VisibleText;
    private Color InvisibleText;
    private Color VisibleImage;
    private Color InvisibleImage;
	private Color VisibleBG;
	private Color InvisibleBG;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        tutorialText = transform.FindChild("HelpText").gameObject.GetComponent<Text>();
        tutorialButtonImage = transform.FindChild("ButtonImage").gameObject.GetComponent<RawImage>();
		tutorialBG = transform.FindChild("BGImage").gameObject.GetComponent<RawImage>();
        Disable();

        VisibleText = tutorialText.color;
        InvisibleText = new Color(tutorialText.color.r, tutorialText.color.g, tutorialText.color.b, 0);
        VisibleImage = tutorialButtonImage.color;
        InvisibleImage = new Color(tutorialButtonImage.color.r, tutorialButtonImage.color.g, tutorialButtonImage.color.b, 0);
		VisibleBG = tutorialBG.color;
		InvisibleBG = new Color(tutorialBG.color.r, tutorialBG.color.g, tutorialBG.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (RemoveTimerCurrent > 0)
        {
            RemoveTimerCurrent -= Time.deltaTime;
            if (RemoveTimerCurrent <= 0)
            {
                RemoveTimerCurrent = 0;
                if (!FadeOut)
                    Disable();
            }
        }

        if (FadeOut)
        {
            FadeOutTimerCurrent -= Time.deltaTime;
            if (FadeOutTimerCurrent <= 0)
            {
                FadeOut = false;
                FadeOutTimerCurrent = 0;
            }
            tutorialText.color = Color.Lerp(VisibleText, InvisibleText, 1 - (FadeOutTimerCurrent / FadeOutTimer));
            tutorialButtonImage.color = Color.Lerp(VisibleImage, InvisibleImage, 1 - (FadeOutTimerCurrent / FadeOutTimer));
			tutorialBG.color = Color.Lerp(VisibleBG, InvisibleBG, 1 - (FadeOutTimerCurrent / FadeOutTimer));
        }
    }

    public void ShowHelp(TutorialProgression.TutorialMessageType p_message)
    {
        FadeOut = false;
        RemoveTimerCurrent = RemoveTimer;
        FadeOutTimerCurrent = FadeOutTimer;
        tutorialText.color = VisibleText;
        tutorialButtonImage.color = VisibleImage;
		tutorialBG.color = VisibleBG;
        if (p_message == TutorialProgression.TutorialMessageType.DashInfo)
        {
            tutorialText.text = "Press to dash";
            tutorialButtonImage.color = new Color(1, 1, 1, 1);
			tutorialBG.color = new Color(1, 1, 1, 1);
            if (dashButtonTexture)
                tutorialButtonImage.texture = dashButtonTexture;
        }
        else if (p_message == TutorialProgression.TutorialMessageType.AttackInfo)
        {
            tutorialText.text = "Press to attack";
            tutorialButtonImage.color = new Color(1, 1, 1, 1);
			tutorialBG.color = new Color(1, 1, 1, 1);
            if (attackButtonTexture)
                tutorialButtonImage.texture = attackButtonTexture;
        }
		else if (p_message == TutorialProgression.TutorialMessageType.ControlInfo)
		{
			tutorialText.text = "Use W,A,S,D to move around";
			tutorialButtonImage.color = new Color(1, 1, 1, 1);
			tutorialBG.color = new Color(1, 1, 1, 1);
			if (moveButtonTexture)
				tutorialButtonImage.texture = moveButtonTexture;
		}
		else if (p_message == TutorialProgression.TutorialMessageType.SpellInfo)
		{
			tutorialText.text = "Use 1,2,3,4 and left click to cast spells";
			tutorialButtonImage.color = new Color(1, 1, 1, 1);
			tutorialBG.color = new Color(1, 1, 1, 1);
			if (spellButtonTexture)
				tutorialButtonImage.texture = spellButtonTexture;
		}
    }

    public void Disable()
    {
        FadeOut = true;
        //tutorialText.text = "";
        //tutorialButtonImage.color = new Color(1, 1, 1, 0);
    }
}
