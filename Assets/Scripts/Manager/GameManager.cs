using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player{get;private set;}
    protected BaseUI baseUI;
    private void Awake()
    {
        Instance = this;
        player = FindAnyObjectByType<PlayerController>();
        player.Init(this);

    }

    public void MiniGameStart(int sceneIndex)
    {
        SceneManager .LoadScene(sceneIndex);
    }
}
