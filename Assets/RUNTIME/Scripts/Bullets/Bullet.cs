
using System;
using RUNTIME.Scripts.Interface;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    protected int BulletSpeed = 20;
    public int damageCount;
    public Cannon cannon;
    protected bool OnShoot;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }


    private void OnEnable()
    {
        OnShoot = true;
    }

    private void OnDisable()
    {
        OnShoot = false;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameState(GameState.InGame))
        {
            
            if (OnShoot==true)
            {
                transform.LookAt(cannon.TargetEnemy.transform);
            }
            _rigidbody.velocity = transform.forward * BulletSpeed;
            OnShoot = false;

        }
    }
    
    
}
