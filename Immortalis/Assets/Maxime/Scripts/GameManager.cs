
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject MenuPause;
    public PlayerInteraction Playerinteraction;
    public Slider sensitivitySliderHorizontal;
    public Slider sensitivitySliderVertical;
    public Player_controller playerController;
    public Slider volumeVoiceSlider;
    public Slider volumeMusicSlider;
    public AudioMixer audioMixerVoice;

    // Start is called before the first frame update
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("VoiceVolume", 5f); // par défaut à mi-volume
        float savedmusicvolume = PlayerPrefs.GetFloat("MusicVolume",0.5f);

        volumeMusicSlider.value = savedmusicvolume;
        volumeVoiceSlider.value = savedVolume;

        SetMusiqueVolume(savedmusicvolume);
        SetVoiceVolume(savedVolume);

        volumeVoiceSlider.onValueChanged.AddListener(SetVoiceVolume);
        volumeMusicSlider.onValueChanged.AddListener(SetMusiqueVolume);

        sensitivitySliderVertical.value = playerController.mouse_sensitivx;
        sensitivitySliderHorizontal.value = playerController.mouse_sensitivy;

        sensitivitySliderVertical.onValueChanged.AddListener(UpdateSensitivityVertical);
        sensitivitySliderHorizontal.onValueChanged.AddListener(UpdateSensitivityHorizontal);
    }

    // Update is called once per frame
    void Update()
    {
        if(Playerinteraction.InteractWithBoss == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuPause.SetActive(true);
                UnityEngine.Cursor.visible = true;
                Time.timeScale = 0;

            }
        }



    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void BackToGame()
    {
        
        Time.timeScale = 1;

        if(Playerinteraction.IsInteract == false)
        {
            UnityEngine.Cursor.visible = false;
        }
    }
    public void UpdateSensitivityHorizontal(float newSens)
    {
        playerController.mouse_sensitivy = newSens;
    }
    public void UpdateSensitivityVertical(float newSens)
    {
        playerController.mouse_sensitivx = newSens;
    }
    public void SetVoiceVolume(float volume)
    {
        //// le volume peut aller de 0 à 20
        //float dB = Mathf.Lerp(0f, 20f, volume);
        audioMixerVoice.SetFloat("VoiceVolume", volume);
        PlayerPrefs.SetFloat("VoiceVolume", volume);
    }

    public void SetMusiqueVolume(float volume)
    {
        //// Convertit la valeur (0.0 - 1.0) en dB (-80 à 0)
        float dB = Mathf.Lerp(-80f, 0f, volume);
        audioMixerVoice.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
