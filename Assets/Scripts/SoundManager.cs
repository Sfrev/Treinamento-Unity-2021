using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton

    public static SoundManager instance;

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

    private float musicVolume = 1f;
    private float SFXVolume = 1f;

    private AudioClip laser, menu, item; // efeitos sonoros
    private AudioClip mainMenu, gameMusic; // musicas
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        laser = Resources.Load<AudioClip>("laser_shooting_sfx");
        menu = Resources.Load<AudioClip>("Menu2A");
        item = Resources.Load<AudioClip>("Item2A");
        mainMenu = Resources.Load<AudioClip>("Juhani Junkala [Retro Game Music Pack] Title Screen");
        gameMusic = Resources.Load<AudioClip>("Juhani Junkala [Retro Game Music Pack] Level 1");
        audioSource.volume = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "Button Click":
                audioSource.PlayOneShot(item, SFXVolume);
                break;
            case "Menu":
                audioSource.PlayOneShot(menu, SFXVolume);
                break;
            case "Laser":
                audioSource.PlayOneShot(laser, SFXVolume);
                break;
            default:
                break;
        }
    }

    public void ChangeMusic(string song)
    {
        switch (song)
        {
            case "Main Menu":
                audioSource.clip = mainMenu;
                audioSource.Play();
                break;
            case "Game Music":
                audioSource.clip = gameMusic;
                audioSource.Play();
                break;
            default:
                break;
        }
    }

    public void ChangeSFXVolume(float value)
    {
        SFXVolume = value;
        PlayerPrefsController.SetSFXVolume(value);
    }

    public void ChangeMusicVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefsController.SetMusicVolume(value);
    }
}
