using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas = null;
    [SerializeField] private GameObject creditsCanvas = null;
    [SerializeField] private GameObject configurationsCanvas = null;

    [SerializeField] Slider musicSlider = null;
    [SerializeField] Slider SFXSlider = null;

    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.instance;
        musicSlider.value = PlayerPrefsController.GetMusicVolume();
        SFXSlider.value = PlayerPrefsController.GetSFXVolume();
    }

    private void Update()
    {
        soundManager.ChangeMusicVolume(musicSlider.value);
        soundManager.ChangeSFXVolume(SFXSlider.value);
    }

    public void CreditsButton()
    {
        soundManager.PlaySound("Button Click");
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void BackFromCreditsButton()
    {
        soundManager.PlaySound("Button Click");
        menuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void ConfigurationsButton()
    {
        soundManager.PlaySound("Button Click");
        menuCanvas.SetActive(false);
        configurationsCanvas.SetActive(true);
    }

    public void BackFromConfigurationsButton()
    {
        PlayerPrefsController.SetMusicVolume(musicSlider.value);
        Debug.Log("Music volume saved and set to " + PlayerPrefsController.GetMusicVolume());

        PlayerPrefsController.SetSFXVolume(SFXSlider.value);
        Debug.Log("SFX volume saved and set to " + PlayerPrefsController.GetSFXVolume());

        soundManager.PlaySound("Button Click");
        menuCanvas.SetActive(true);
        configurationsCanvas.SetActive(false);
    }
}
