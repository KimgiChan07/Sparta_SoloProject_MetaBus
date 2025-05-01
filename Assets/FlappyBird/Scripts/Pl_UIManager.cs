using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pl_UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI reStartText;

    void Start()
    {
        if (reStartText == null)
        {
            Debug.Log("null");
        }

        if (scoreText == null)
        {
            Debug.Log("null");
        }
        reStartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        reStartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
  
}