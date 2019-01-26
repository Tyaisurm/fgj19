using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void start() {
        PlayerControl.lorePhase = 1;
    }

	public void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void QuitGame() {
        Debug.Log("QUIT BUTTON PRESSED");
        Application.Quit();
    }
}
