using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    private Pl_UIManager pl_UIManager;
    
    [SerializeField]private Button startButton;
    [SerializeField]private Button exitButton;

    private void Start()
    {
        pl_UIManager = FindObjectOfType<Pl_UIManager>();
        startButton.onClick.AddListener(OnStartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnStartButtonClick()
    {
        Time.timeScale = 1;
        pl_UIManager.Setstart();
        FindObjectOfType<Pl_Player>().GetGameStart(true);
    }

    private void OnExitButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
