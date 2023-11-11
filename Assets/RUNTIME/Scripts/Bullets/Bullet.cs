﻿using System;
using UnityEngine;
public class Bullet : MonoBehaviour
{

    private Rigidbody _rigidbody;
    protected int BulletSpeed = 20;
    public Cannon cannon;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = cannon.transform.forward * BulletSpeed;
    }
}
