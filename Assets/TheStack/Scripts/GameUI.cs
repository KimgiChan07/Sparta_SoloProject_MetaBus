using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : The_BaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;
    TextMeshProUGUI maxComboText;
    protected override The_UIState GetUIState()
    {
        return The_UIState.Game;
    }


    public override void Init(The_UIManager theUIManager)
    {
        base.Init(theUIManager);
        
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
        maxComboText=  transform.Find("MaxComboText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score, int combo, int maxCombo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        maxComboText.text = maxCombo.ToString();
    }
}
