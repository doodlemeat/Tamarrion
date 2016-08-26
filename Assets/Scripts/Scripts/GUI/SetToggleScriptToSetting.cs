using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetToggleScriptToSetting : MonoBehaviour
{
    public enum SettingType
    {
        Invert_Xaxis,
        Invert_Yaxis,
    }

    public SettingType settingType;

    void Start()
    {
        if (Settings.instance)
        {
            if(settingType == SettingType.Invert_Xaxis)
                GetComponent<Toggle>().isOn = Settings.instance.Inverted_Xaxis;
            else if (settingType == SettingType.Invert_Yaxis)
                GetComponent<Toggle>().isOn = Settings.instance.Inverted_Yaxis;
        }
    }
}
