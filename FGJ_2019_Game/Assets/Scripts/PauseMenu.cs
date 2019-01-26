using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject[] pausedGame;

    // Start is called before the first frame
    void Start()
    {
        Time.timeScale = 1;
        pausedGame = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "space_test")
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    showPaused();
                }
                else if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    hidePaused();
                }
            }
        }
    }

    // Press "Continue", unpauses game
    public void Continue()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    // For when user presses "Exit to Menu"; returns them to main menu
    public void ExitToMenu()
    {
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }

    // Shows pause menu
    public void showPaused()
    {
        foreach(GameObject x in pausedGame)
        {
            x.SetActive(true);
        }
    }

    // Hides pause menu
    public void hidePaused()
    {
        foreach (GameObject x in pausedGame)
        {
            x.SetActive(false);
        }
    }
}
