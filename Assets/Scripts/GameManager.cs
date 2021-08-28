using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas = null;
    [SerializeField] private GameObject pauseCanvas = null;

    private SceneManagement sceneManagement;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManagement = SceneManagement.instance;
        soundManager = SoundManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButton()
    {
        Time.timeScale = 1f; // Voltar o tempo para sua escala normal
        soundManager.PlaySound("Button Click");
        sceneManagement.LoadMenuScene();
    }

    public void PauseButton()
    {
        Time.timeScale = 0f; // Congelar o tempo
        soundManager.PlaySound("Button Click");
        mainCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void BackFromPause()
    {
        Time.timeScale = 1f; // Voltar o tempo para sua escala normal
        soundManager.PlaySound("Button Click");
        mainCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
}
