using System;
using UnityEngine;
public class Bullet : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private int _bulletSpeed = 20;
    public Cannon cannon;

    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = cannon.transform.forward * _bulletSpeed;
    }
}
