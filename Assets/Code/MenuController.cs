using Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    // Outlets
    public GameObject mainMenu;

    private void Awake()
    {
        instance = this;
        Hide();
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(true);
        Time.timeScale = 0;
        SkiControls.instance.isPaused = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if(SkiControls.instance != null)
        {
            SkiControls.instance.isPaused = false;
        }
    }

    public void SwitchLevel(int levelIndex)
    {
        Hide();
        SceneManager.LoadScene(levelIndex);
    }
}
