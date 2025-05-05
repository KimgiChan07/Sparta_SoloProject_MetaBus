using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player { get; private set; }
    private ImageManager imageManager;
    protected BaseUI baseUI;

    private void Awake()
    {
        Instance = this;
        imageManager = GetComponentInChildren<ImageManager>();
        player = FindAnyObjectByType<PlayerController>();
        player.Init(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        SavePlayerPos();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void MiniGameStart(int sceneIndex)
    {
        SavePlayerPos();
        SceneManager.LoadScene(sceneIndex);
    }

    private void SavePlayerPos()
    {
        if (player != null)
        {
            Vector3 pos = player.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", pos.x);
            PlayerPrefs.SetFloat("PlayerPosY", pos.y);
            PlayerPrefs.SetFloat("PlayerPosZ", pos.z);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("No player found");
        }
    }

}