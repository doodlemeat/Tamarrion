using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ErrorBar : MonoBehaviour
{
    public static ErrorBar instance;

    public GameObject ErrorText;
    public float HorizontalRange = 10;

    void Awake()
    {
        instance = this;
    }

    public void SpawnText(string p_textString)
    {
        if (!ErrorText)
            return;

        GameObject inst = (GameObject)Instantiate(ErrorText, gameObject.transform.position + new Vector3(Random.Range(-HorizontalRange, HorizontalRange), 0, 0), Quaternion.identity);
        inst.GetComponent<Text>().text = p_textString;
        inst.transform.SetParent(gameObject.transform);
    }

    public void SpawnText(string p_textString, Color p_textColor)
    {
        if (!ErrorText)
            return;

        GameObject inst = (GameObject)Instantiate(ErrorText, gameObject.transform.position + new Vector3(Random.Range(-HorizontalRange, HorizontalRange), 0, 0), Quaternion.identity);
        inst.GetComponent<Text>().text = p_textString;
        inst.GetComponent<Text>().color = p_textColor;
        inst.transform.SetParent(gameObject.transform);
    }
}
