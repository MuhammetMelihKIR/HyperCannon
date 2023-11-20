
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


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
    private GameState _gameState;

    public static Action<GameState> OnGameStateChanged;
    public static Action OnGameLevelUpdate;
  
    public int gameLevelCount;
    private int _levelGoalCount;
    private int _enemiesKillsCount;
    private int _goldCount;

    [Header("BUTTONS")]
    private int _redButtonLevelCount = 1;
    private int _blueButtonLevelCount = 1;
    private int _yellowButtonLevelCount= 1;
    
    private int _redButtonGoldCount = 1;
    private int _blueButtonGoldCount = 1;
    private int _yellowButtonGoldCount = 1;

    public RedBullet redBullet;
    public BlueBullet blueBullet;
    public YellowBullet yellowBullet;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        Init();
    }
    
    void OnEnable()
    {
        OnGameStateChanged += SetGameState;
        Enemy.OnEnemyDie += OnEnemiesKilled;
    }

    void OnDisable()
    {
        OnGameStateChanged -= SetGameState;
        Enemy.OnEnemyDie -= OnEnemiesKilled;
    }
    
    private void SetGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public bool IsGameState(GameState gameState)
    {
        return _gameState == gameState;
    }

    private void Init()
    {
        gameLevelCount = 1;
        _levelGoalCount = (10 * gameLevelCount);
        UIManager.Instance.enemiesKillsCountText.text = _enemiesKillsCount + " / " + (_levelGoalCount).ToString();
        UIManager.Instance.redButtonGoldText.text = _redButtonGoldCount.ToString();
        UIManager.Instance.redButtonLevelText.text = "LVL- " + _redButtonLevelCount.ToString(); 
        UIManager.Instance.blueButtonGoldText.text = _blueButtonGoldCount.ToString();
        UIManager.Instance.blueButtonLevelText.text ="LVL- " +  _blueButtonLevelCount.ToString();
        UIManager.Instance.yellowButtonGoldText.text = _yellowButtonGoldCount.ToString();
        UIManager.Instance.yellowButtonLevelText.text = "LVL- " + _yellowButtonLevelCount.ToString();
        UIManager.Instance.levelText.text = "LEVEL- " + gameLevelCount.ToString(); 
    }
    
    private void OnEnemiesKilled()
    {
        _goldCount++; 
        UIManager.Instance. goldText.text = _goldCount.ToString();
        _enemiesKillsCount++;
        UIManager.Instance.enemiesKillsCountText.text = _enemiesKillsCount + " / " + (_levelGoalCount).ToString();

        if (_enemiesKillsCount == _levelGoalCount)
        {
            OnGameStateChanged?.Invoke(GameState.Win);
        }

    }

    public void UpdateGameLevel()
    {
        gameLevelCount++;
        _enemiesKillsCount = 0;
        _levelGoalCount = (10 * gameLevelCount);
        UIManager.Instance.enemiesKillsCountText.text = _enemiesKillsCount + " / " + (_levelGoalCount).ToString();
        UIManager.Instance.levelText.text = "LEVEL- " + gameLevelCount.ToString();
    }

    #region CANVAS BUTTONS

    public void StartButton()
    {
        OnGameStateChanged?.Invoke(GameState.InGame);
       
    }

    public void NextLevelButton()
    {
        UpdateGameLevel();
        OnGameStateChanged?.Invoke(GameState.InGame);
        OnGameLevelUpdate?.Invoke();
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
 

    #region LEVEL UP BUTTONS

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
            redBullet.UpdateDamage();


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
            blueBullet.UpdateDamage();
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
            yellowBullet.UpdateDamage();
            
        }
        
    }

    #endregion
    
}
