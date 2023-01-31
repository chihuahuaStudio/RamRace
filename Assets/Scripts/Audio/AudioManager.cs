/******************************************************************************
 * Script by Chihuahua Studio  
******************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button audioButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button helpButton;
    [SerializeField] Button mainMenuButton;

    private void Awake()
    {
        startButton.onClick.AddListener(PlayStartButtonSound);
        audioButton.onClick.AddListener(PlayAudioButtonSound);
        quitButton.onClick.AddListener(PlayQuitButtonSound);
        helpButton.onClick.AddListener(PlayHelpButtonSound);
        mainMenuButton.onClick.AddListener(PlayMainMenuButtonSound);
    }

    private void PlayMainMenuButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/MainMenuButtonSFX", transform.position);
    }

    public void PlayStartButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/StartButtonSFX", transform.position);
    }
    public void PlayAudioButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/AudioButtonSFX", transform.position);
    }
    public void PlayQuitButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/HelpButtonSFX", transform.position);
    }
    public void PlayHelpButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/QuitButtonSFX", transform.position);
    }
}
