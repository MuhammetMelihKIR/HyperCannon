using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{

    private Rigidbody _rigidbody;
    protected int BulletSpeed = 20;
    public GameObject cannon;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameState(GameState.InGame))
        {
            _rigidbody.velocity = cannon.transform.forward * BulletSpeed;
        }
        

    }
}
