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
        HpCount = 5;
        DamageCount = 1;
        MoveSpeed = 2;
        HpText.text = HpCount.ToString(); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected void LevelUp()
    {
        DamageCount += 1;
    }
    protected void Move()
    {
        Rigidbody.velocity = -transform.forward * MoveSpeed;
    }
   
}
