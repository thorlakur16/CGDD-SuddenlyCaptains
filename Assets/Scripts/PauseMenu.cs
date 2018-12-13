using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update () {
        //Debug.Log("startsadasdasd");
        //Debug.Log(es.firstSelectedGameObject);

            if (Input.GetButtonDown("Start_P1") || Input.GetButtonDown("Start_P2"))
            {
                //Debug.Log("start");
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    } 
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
    }
    
}
