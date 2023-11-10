using System;
using System.Collections;
using Runtime.Scripts;
using UnityEngine;

public class RedCannon : Cannon
{
    private void Awake()
    {
        BulletCount = 0;
    }

    private void Update()
    {
        
        AllEnemies = GameObject.FindObjectsOfType<RedEnemy>();
       
    }
    
    
}
