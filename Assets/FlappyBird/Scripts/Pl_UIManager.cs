using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pl_UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
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
        titlePanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

  
}