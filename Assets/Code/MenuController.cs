using Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    // Outlets
    public GameObject mainMenu;
    public Button[] levelButtons;

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

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i > PlayerPrefs.GetInt("sceneReached"))
            {
                levelButtons[i].interactable = false;

            }
            else
            {
                levelButtons[i].interactable=true;
            }
        }
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
