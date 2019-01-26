using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static int lorePhase;
    public TextAsset lore;
    private string[] passages;
    public Text loretext;
    public GameObject panel;
    void start() {

    }

	public void PlayGame () {
        PlayerControl.lorePhase = 1;
        ActivateLore();
	}

    public void QuitGame() {
        Debug.Log("QUIT BUTTON PRESSED");
        Application.Quit();
    }

    void ActivateLore () {
        passages = lore.text.Split('\n');

        panel.SetActive(true);
        string totext = "";

        print("yay");

        foreach (string pass in passages) {
            if (pass.StartsWith("1")) {
                totext = totext + pass.Substring(1) + "\n\n";
            }
        }

        loretext.text = totext;

        PlayerControl.lorePhase++;

        gameObject.SetActive(false);
    }

    public void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Egg");
            SceneManager.LoadScene("home", LoadSceneMode.Single);
        }
    }
}
