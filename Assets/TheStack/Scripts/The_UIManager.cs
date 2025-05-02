using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum The_UIState
{
    Home,
    Game,
    Score
}
    

public class The_UIManager : MonoBehaviour
{
   static The_UIManager instance;

   public static The_UIManager Instance
   {
       get{return instance;}
   }
   The_UIState currentState = The_UIState.Home;
   private HomeUI homeUI = null;
   private GameUI gameUI = null;
   private ScoreUI scoreUI = null;
   
   TheStack theStack = null;

   private void Awake()
   {
       instance=this;

       theStack = FindObjectOfType<TheStack>();

       homeUI = GetComponentInChildren<HomeUI>(true);
       homeUI?.Init(this);

       gameUI = GetComponentInChildren<GameUI>(true);
       gameUI?.Init(this);

       scoreUI = GetComponentInChildren<ScoreUI>(true);
       scoreUI?.Init(this);
       
       ChangeState(The_UIState.Home);
   }

   public void ChangeState(The_UIState state)
   {
       currentState = state;
       homeUI?.SetActive(currentState);
       gameUI?.SetActive(currentState);
       scoreUI?.SetActive(currentState);
   }

   public void OnClickStart()
   {
       theStack.ReStart();
       ChangeState(The_UIState.Game);
   }

   public void OnClickExit()
   {
       SceneManager.LoadScene(0);
   }

   public void UpdateScore()
   {
       gameUI.SetUI(theStack.Score,theStack.Combo,theStack.MaxCombo);
   }

   public void SetScoreUI()
   {
       scoreUI.SetUI(theStack.Score,theStack.MaxCombo,theStack.BestScore,theStack.BestCombo);
       ChangeState(The_UIState.Score);
   }
}
