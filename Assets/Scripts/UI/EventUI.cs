using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : BaseUI
{
    [SerializeField]private Button startButton;
    
    [SerializeField] private int sceneIndex;
    
    [SerializeField]private TextMeshProUGUI bestScoreText;
    
    public UIState uiState;
    
    private RectTransform[] childPanels;


    public override void Init(UIManager _uiManager)
    {
        base.Init(_uiManager);
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnClickStartButton);
        }
        else
        {
            return;
        }

        UpdateBestScore();
    }

    private void Awake()
    {
        childPanels = GetComponentsInChildren<RectTransform>(true);
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.MiniGameStart(sceneIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MiniGameManager.Instance.ResetBestScore(uiState.ToString());
            UpdateBestScore();
        }
    }

    public void UpdateBestScore()
    {
        if (bestScoreText != null && MiniGameManager.Instance != null)
        {
            int bestScore= MiniGameManager.Instance.GetBestScore(uiState.ToString());
            bestScoreText.text = bestScore.ToString();
        }
        else
        {
            return;
        }
    }

    public override void SetUIShow()
    {
        base.SetUIShow(); 
        SetActive(true);
    }

    public override void SetUIHide()
    {
        SetActive(false);
        UpdateBestScore();
        base.SetUIHide();
    }

    private void SetActive(bool _isActive)
    {
        if (childPanels == null) return;
        foreach (var child in childPanels)
        {
            if (child != null && child != this.transform && child.gameObject != null)
                child.gameObject.SetActive(_isActive);
            else
            {
                return;
            }
        }
    }
}
