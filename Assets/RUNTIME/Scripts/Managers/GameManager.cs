using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState 
{ 
    ReadyToStartGame, 
    InGame,
    Win,
    Lose,
        
}
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public static Action<GameState> OnGameStateChanged;
    
    public static Action OnLevelUpBlueButton;
    public static Action OnLevelUpYellowButton;
    public static Action OnLevelUpRedButton;

    private int _gameLevelCount;

    
    private int _redButtonLevelCount = 1;
    private int _blueButtonLevelCount = 1;
    private int _yellowButtonLevelCount=1;

    private int _goldCount = 100;
    private int _redButtonGoldCount = 1;
    private int _blueButtonGoldCount = 1;
    private int _yellowButtonGoldCount = 1;
   
    public GameState gameState = GameState.ReadyToStartGame;

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
        UIManager.Instance.redButtonGoldText.text = _redButtonGoldCount.ToString();
        UIManager.Instance.redButtonLevelText.text = "LVL- " + _redButtonLevelCount.ToString(); 
        UIManager.Instance.blueButtonGoldText.text = _blueButtonGoldCount.ToString();
        UIManager.Instance.blueButtonLevelText.text ="LVL- " +  _blueButtonLevelCount.ToString();
        UIManager.Instance.yellowButtonGoldText.text = _yellowButtonGoldCount.ToString();
        UIManager.Instance.yellowButtonLevelText.text = "LVL- " + _yellowButtonLevelCount.ToString();
    }

    void OnEnable()
    {
        OnGameStateChanged += SetGameState;
        Enemy.OnEnemyDie += MainGoldTextUpdate;
    }

    void OnDisable()
    {
        OnGameStateChanged -= SetGameState;
        Enemy.OnEnemyDie -= MainGoldTextUpdate;
    }

    void Start()
    {
        OnGameStateChanged.Invoke(gameState);
    }
    
    public bool IsState(GameState state)
    {
        return gameState == state;
    }
   
    private void SetGameState(GameState state)
    {
        gameState = state;
    }
   
    private void MainGoldTextUpdate()
    {
        _goldCount++;
       UIManager.Instance. goldText.text = _goldCount.ToString();
        
    }

    public void RedButtonGoldCountUpdate()
    {
        if (_goldCount>=_redButtonGoldCount)
        {
            _goldCount -= _redButtonGoldCount;
            _redButtonLevelCount++;
            _redButtonGoldCount *= 2;
            UIManager.Instance.redButtonGoldText.text = _redButtonGoldCount.ToString();
            UIManager.Instance.redButtonLevelText.text = "LVL- " + _redButtonLevelCount.ToString();
            UIManager.Instance.goldText.text = _goldCount.ToString();
            OnLevelUpRedButton?.Invoke();
            
        }
       
    }
    public void BlueButtonGoldCountUpdate()
    {
        if (_goldCount>=_blueButtonGoldCount)
        {
            _goldCount -= _blueButtonGoldCount;
            _blueButtonLevelCount++;
            _blueButtonGoldCount *= 2;
            UIManager.Instance.blueButtonGoldText.text = _blueButtonGoldCount.ToString();
            UIManager.Instance.blueButtonLevelText.text ="LVL- " +  _blueButtonLevelCount.ToString();
            UIManager.Instance.goldText.text = _goldCount.ToString();
            OnLevelUpBlueButton?.Invoke();
        }
        
    }
    public void YellowButtonGoldCountUpdate()
    {
        if (_goldCount>=_yellowButtonGoldCount)
        {
            _goldCount -= _yellowButtonGoldCount;
            _yellowButtonLevelCount++;
            _yellowButtonGoldCount *= 2;
            UIManager.Instance.yellowButtonGoldText.text = _yellowButtonGoldCount.ToString();
            UIManager.Instance.yellowButtonLevelText.text = "LVL- " + _yellowButtonLevelCount.ToString();
            UIManager.Instance.goldText.text = _goldCount.ToString();
            OnLevelUpYellowButton?.Invoke();
        }
        
    }
}
