using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public TextMeshProUGUI goldText;
    
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
    }
   
}
