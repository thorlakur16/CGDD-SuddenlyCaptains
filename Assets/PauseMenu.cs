using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public EventSystem es;
    private GameObject storeSelected;

    void Awake()
    {
        storeSelected = es.firstSelectedGameObject;
        GameIsPaused = true;
        //Time.timeScale = 0f;
        //Debug.Log(storeSelected);
    }
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
        if (GameIsPaused)
        {
            //Debug.Log("viddifag");
            
            if (es.currentSelectedGameObject != storeSelected)
            {
                Debug.Log(es.currentSelectedGameObject);
                Debug.Log(storeSelected);
                if (es.currentSelectedGameObject == null)
                {
                    es.SetSelectedGameObject(storeSelected);
                }
                else
                {
                    storeSelected = es.currentSelectedGameObject;
                }
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
