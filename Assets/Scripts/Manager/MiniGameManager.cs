using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }
    protected Dictionary<string, int> bestScores = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateScore(string gameName, int currentScore)
    {
        string key = $"BestScore_{gameName}";
        int saveScore = PlayerPrefs.GetInt(key, 0);
        if (currentScore >= saveScore)
        {
            PlayerPrefs.SetInt(key, currentScore);
            PlayerPrefs.Save();
            bestScores[key] = currentScore;
        }
    }

    public int GetBestScore(string gameName)
    {
        string key = $"BestScore_{gameName}";
        if (!bestScores.ContainsKey(key))
        {
            bestScores[key] = PlayerPrefs.GetInt(key, 0);
        }
        return bestScores[key];
    }

    public void ResetBestScore(string gameName)
    {
        Debug.Log("BestScore: " + PlayerPrefs.GetInt("BestScore")+" -> 0");
        string key = $"BestScore_{gameName}";
        PlayerPrefs.SetInt(key, 0);
        PlayerPrefs.Save();
        bestScores[key] = 0;
    }
}