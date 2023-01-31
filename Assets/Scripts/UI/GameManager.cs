using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
   

    [Header("References")]
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject helpScreen;
    [SerializeField] GameObject audioScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject hudDisplay;
    [SerializeField] GameObject audioTitle;
    [SerializeField] GameObject masterControls;
    [SerializeField] GameObject musicControls;
    [SerializeField] GameObject sfxControls;
    [SerializeField] Player playerScript;
    [SerializeField] StartGame startGameScript;

    [Header("Game States")]
    [SerializeField] bool isGameStarted;
    [SerializeField] bool isGamePause;
    [SerializeField] bool isGameOver;

    [Header("Game Controls")]
    [SerializeField] KeyCode pauseKey;

    

    private void Update()
    {
        isGameOver = playerScript.isGameOver;
        isGameStarted = startGameScript.isGameActive;

       

        if (startGameScript.isGameActive == true && !isGamePause)
        {
            PauseGame();
            LoadHudDisplay();
        }
        else if(isGamePause)
        {
            UnPauseGame();
        }
    }
    public void LoadHelpScreen()
    {
        startScreen.SetActive(false);
        helpScreen.SetActive(true);
    }

    public void LoadMainMenuScreen()
    {
        helpScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void LoadAudioScreen()
    {
        startScreen.SetActive(false);
        audioScreen.SetActive(true);
    }

    public void LoadMainMenuScreen2()
    {
        audioScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    private void PauseGame()
    {
        if(Input.GetKeyDown(pauseKey) && isGameStarted && !isGamePause)
        {
            isGamePause = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            audioScreen.SetActive(true);
            audioTitle.SetActive(false);
            mainMenuButton.SetActive(false);
           
        }
    }

    private void UnPauseGame()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            isGamePause = false;
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            audioScreen.SetActive(false);


        }
    }

    private void LoadHudDisplay()
    {
        if(isGameStarted)
        {
            hudDisplay.SetActive(true);
        }
    }



    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }


}
