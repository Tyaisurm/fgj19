using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharByChar : MonoBehaviour
{
    [TextArea]
    public string finalText;
    public float time;
    private string currentText = "";

    void Start()
    {
        StartCoroutine(PrintLoop());
    }

    IEnumerator PrintLoop()
    {
        for(int i = 0; i < finalText.Length; i++)
        {
            currentText = finalText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(time);
        }
    }
}
