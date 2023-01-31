using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioControls : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    private string _masterParameter = "masterParameter";
    private FMOD.Studio.Bus masterBus;

    [SerializeField] Slider musicSlider;
    private string _musicParameter = "musicParameter";
    private FMOD.Studio.Bus musicBus;

    [SerializeField] Slider sfxSlider;
    private string _sfxParameter = "sfxParameter";
    private FMOD.Studio.Bus sfxBus;
    

    private void Awake()
    {
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/");
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFXs");

        masterSlider.onValueChanged.AddListener(MasterSliderControl);
        musicSlider.onValueChanged.AddListener(MusicSliderControl);
        sfxSlider.onValueChanged.AddListener(SfxSliderControl);

        masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;
    }

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(_masterParameter, masterSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat(_musicParameter, musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat(_sfxParameter, sfxSlider.value);
    }

    private void MasterSliderControl(float masterSliderValue)
    {
        masterBus.setVolume(masterSliderValue);
    }

    private void MusicSliderControl(float musicSliderValue)
    {
        musicBus.setVolume(musicSliderValue);
    }

    private void SfxSliderControl(float sfxSliderValue)
    {
        sfxBus.setVolume(sfxSliderValue);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_masterParameter, masterSlider.value);
        PlayerPrefs.SetFloat(_musicParameter, musicSlider.value);
        PlayerPrefs.SetFloat(_sfxParameter, sfxSlider.value);
    }
}
