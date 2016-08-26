using UnityEngine;
using System.Collections;

public class VolumeSlider : MonoBehaviour
{
    void Start()
    {
        GetComponent<UnityEngine.UI.Slider>().value = AudioListener.volume;
        GetComponent<UnityEngine.UI.Slider>().onValueChanged.AddListener(OnClick);
    }

    void OnClick(float p_value)
    {
        AudioListener.volume = p_value;
    }
}
