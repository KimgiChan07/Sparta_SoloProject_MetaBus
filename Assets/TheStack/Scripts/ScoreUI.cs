using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : The_BaseUI
{

    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;
    TextMeshProUGUI bestComboText;
    TextMeshProUGUI bestScoreText;

    Button startButton;
    Button exitButton;

    protected override The_UIState GetUIState()
    {
        return The_UIState.Score;
    }


    public override void Init(The_UIManager theUIManager)
    {
        base.Init(theUIManager);
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
        bestComboText = transform.Find("BestComboText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        
        startButton.onClick.AddListener(OnclickstartButton);
        exitButton.onClick.AddListener(OnclickexitButton);
    }

    public void SetUI(int score, int combo, int bestScore,int bestCombo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        bestComboText.text = bestCombo.ToString();
        bestScoreText.text = bestScore.ToString();
    }
    void OnclickstartButton()
    {
        TheUIManager.OnClickStart();
    }

    void OnclickexitButton()
    {
        TheUIManager.OnClickExit();
    }

}
