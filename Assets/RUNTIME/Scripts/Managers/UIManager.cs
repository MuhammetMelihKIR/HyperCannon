
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public TextMeshProUGUI goldText;

    public TextMeshProUGUI enemiesKillsCountText;
    public TextMeshProUGUI levelText;
    
    
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
        readyToStartPanel.SetActive(CloseAllPanelExceptThis());
    }

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= UpdateUI;
    }

    private void UpdateUI(GameState state)
    {
       switch (state)
        {
            case GameState.ReadyToStartGame:
                readyToStartPanel.SetActive(CloseAllPanelExceptThis());
                
                break;
            case GameState.InGame:
                inGamePanel.SetActive(CloseAllPanelExceptThis());
               
                break;
            case GameState.Win:
                winPanel.SetActive(CloseAllPanelExceptThis());
               
                break;
            case GameState.Lose:
                losePanel.SetActive(CloseAllPanelExceptThis());
               
                break;
            
        }
       
    }
    
    bool CloseAllPanelExceptThis()
    {
        inGamePanel.SetActive(false);
        readyToStartPanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);

        return true;
    }

    
}
