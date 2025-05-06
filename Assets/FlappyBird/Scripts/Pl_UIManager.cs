using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pl_UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titlePanel;

    void Start()
    {
        if (scoreText == null)
        {
            Debug.Log("null");
        }
    }
    public void Setstart()
    {
        gameOverText.gameObject.SetActive(false);
        titlePanel.SetActive(false);
    }

    public void SetGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

  
}