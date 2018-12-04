using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
    public EventSystem es;
    private GameObject storeSelected;
    // Use this for initialization
    void Start()
    {
        storeSelected = es.firstSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (es.currentSelectedGameObject != storeSelected)
        {
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
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
