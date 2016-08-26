using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DifficultyMarker : MonoBehaviour
{
    public static DifficultyMarker instance;
    public List<Texture> diffTextures = new List<Texture>();
    private RawImage image;

    void Awake()
    {
        instance = this;
        image = gameObject.GetComponent<RawImage>();
    }

    public void SetDifficultyTexture(Difficulty.difficulty p_diff)
    {
        if ((int)p_diff > diffTextures.Count - 1)
            return;

        image.texture = diffTextures[(int)p_diff];
    }
}
