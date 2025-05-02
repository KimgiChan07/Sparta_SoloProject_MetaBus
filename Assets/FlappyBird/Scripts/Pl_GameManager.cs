using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pl_GameManager : MonoBehaviour
{
    static Pl_GameManager _plGameManager;
    public static Pl_GameManager Instance { get { return _plGameManager; } }

    Pl_UIManager _plUIManager;    
    public Pl_UIManager PlUIManager {get{return _plUIManager;}}
    
    private int currentScore=0;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Awake()
    {
        _plGameManager = this;
        _plUIManager = FindObjectOfType<Pl_UIManager>();
    }

    public void GameOver()
    {
        MiniGameManager.Instance.UpdateScore("FlappyBird", currentScore);
        _plUIManager.Setstart();
        Debug.Log("GameOver");
    }

    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        
        currentScore += score;
        _plUIManager.UpdateScore(currentScore);
        Debug.Log("점수: "+currentScore);
    }
}
