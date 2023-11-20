using System;
using Runtime.Scripts;
using TMPro;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public static Action OnEnemyDie;

    private Rigidbody _rigidbody;
    private int _moveSpeed;
    private int _averageHp;
    
    protected TextMeshPro HpText;
    protected int HpCount;
    
    protected void Awake()
    { 
        HpText = GetComponentInChildren<TextMeshPro>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        GameManager.OnGameLevelUpdate += ResetEnemyValues;
    }

    private void Start()
    {
       
        ResetEnemyValues();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameState(GameState.InGame))
        {
            Move();
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
            GameManager.OnGameStateChanged?.Invoke(GameState.Lose);
        }
    }
    
    protected void ResetEnemyValues()
    {
        _averageHp = Random.Range(7,10);
        HpCount = _averageHp * GameManager.Instance.gameLevelCount ;
        HpText.text = HpCount.ToString();
        _moveSpeed = 2;
    }
    
    private void Move()
    {
        _rigidbody.velocity = -transform.forward * _moveSpeed;
       
    }

 

   
}
