using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool isGameActive;
   [SerializeField] private GameObject startScreen;
   [SerializeField] private GameObject game;
   
   public void StartGameButton()
   {
      isGameActive = true;
      startScreen.SetActive(false);
      game.SetActive(true);
   }
}
