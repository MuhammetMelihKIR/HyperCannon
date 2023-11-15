using System;
using Runtime.Scripts;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action OnEnemyDie;
    
    protected Rigidbody Rigidbody;
    protected TextMeshPro HpText;
    protected int HpCount;
    protected int DamageCount;
    protected int MoveSpeed;
    protected void Awake()
    { 
        HpText = GetComponentInChildren<TextMeshPro>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        HpCount = 5555;
        DamageCount = 1;
        MoveSpeed = 2;
        HpText.text = HpCount.ToString(); 
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameState(GameState.InGame))
        {
            Move();
        }

        if (GameManager.Instance.IsGameState(GameState.Lose))
        {
            transform.position = Vector3.zero;
            Debug.Log("deneme");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOver"))
        {
           GameManager.OnGameStateChanged?.Invoke(GameState.Lose);
        }
    }

    protected void LevelUp()
    {
        DamageCount += 1;
    }
    private void Move()
    {
        Rigidbody.velocity = -transform.forward * MoveSpeed;
       
    }
   
}
