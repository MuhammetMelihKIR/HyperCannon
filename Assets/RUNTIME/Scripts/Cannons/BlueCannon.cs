using System;
using System.Collections;
using Runtime.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class BlueCannon : Cannon
{
    private void Awake()
    {
        
        BulletCount = 1;
    }

    private void Update()
     {
         AllEnemies = GameObject.FindObjectsOfType<BlueEnemy>();
     }
     
     

}
