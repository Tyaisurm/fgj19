using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                hidePaused();
            }
            else 
            {
                Time.timeScale = 0;
                showPaused();
            }
        }
    }

    // For when user presses "Exit to Menu"; returns them to main menu
    public void ExitToMenu()
    {
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }

    // Shows pause menu
    void showPaused()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    // Hides pause menu
    public void hidePaused()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
