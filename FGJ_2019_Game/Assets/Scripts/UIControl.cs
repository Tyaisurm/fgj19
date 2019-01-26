using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public GameObject player;
    private Text speedtext;
    private PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        speedtext = gameObject.GetComponent<Text>();
        pc = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            speedtext.text = string.Concat("Speed: ", Mathf.Round(pc.actualSpeed * 1000).ToString());
            if (pc.actualSpeed > 0.04) {
                speedtext.color = Color.red;
            } else {
                speedtext.color = Color.white;
            }
        }
    }
}
