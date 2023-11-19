using System;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action OnEnemyDie;
    
    protected Rigidbody Rigidbody;
    protected TextMeshPro HpText;
    protected int HpCount;
    protected int MoveSpeed;
    protected void Awake()
    { 
        HpText = GetComponentInChildren<TextMeshPro>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        HpCount = GameManager.Instance.gameLevelCount * 10;
        HpText.text = HpCount.ToString(); 
        MoveSpeed = 2;
        
    }

    protected void ResetEnemyValues()
    {
        HpCount = GameManager.Instance.gameLevelCount * 10;
        HpText.text = HpCount.ToString(); 
        
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameState(GameState.InGame))
        {
            Move();
        }
        
    }
    
    private void Move()
    {
        Rigidbody.velocity = -transform.forward * MoveSpeed;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
           GameManager.OnGameStateChanged?.Invoke(GameState.Lose);
        }
    }

   
}
