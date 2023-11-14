using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public TextMeshProUGUI goldText;

    public TextMeshProUGUI enemiesKillsCountText;
    
    [Header("PANELS")] 
    public GameObject readyToStartPanel;
    public GameObject inGamePanel;
    public GameObject losePanel;
    public GameObject winPanel;
    
    
    [Header("BUTTON LEVEL TEXT")]
    public TextMeshProUGUI redButtonLevelText;
    public TextMeshProUGUI blueButtonLevelText;
    public TextMeshProUGUI yellowButtonLevelText;
    [Header("BUTTON GOLD TEXT")]
    public TextMeshProUGUI redButtonGoldText;
    public TextMeshProUGUI blueButtonGoldText;
    public TextMeshProUGUI yellowButtonGoldText;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        Init();
    }

    private void Init()
    {
        inGamePanel.SetActive(false);
        readyToStartPanel.SetActive(true);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }
    public void StartButton()
    {
        inGamePanel.SetActive(true);
        readyToStartPanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        
    }
    
}
