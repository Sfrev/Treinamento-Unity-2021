using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    #region Singleton

    public static SceneManagement instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private SoundManager soundManager;

    void Start()
    {
        soundManager = SoundManager.instance;
    }

    public void LoadGameScene()
    {
        soundManager.PlaySound("Button Click");
        soundManager.ChangeMusic("Game Music");
        SceneManager.LoadScene("Game Scene");
    }

    public void LoadMenuScene()
    {
        soundManager.PlaySound("Button Click");
        soundManager.ChangeMusic("Main Menu");
        SceneManager.LoadScene("Menu Scene");
    }

    public void ExitGame()
    {
        soundManager.PlaySound("Button Click");
        Application.Quit();
    }
}
