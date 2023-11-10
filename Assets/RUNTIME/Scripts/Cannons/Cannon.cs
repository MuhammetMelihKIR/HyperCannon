using System;
using System.Collections;
using Runtime.Scripts;
using UnityEngine;

 public class Cannon : MonoBehaviour
 {
     protected GameObject TargetEnemy;
     protected Enemy[] AllEnemies;
     private float _attackSpeed = 0.5f;

     protected int BulletCount;


     private void Start()
     {
        StartCoroutine(BulletFire());
     }
  

     private void FixedUpdate()
     {
         FindClosestEnemy();
         LookAtEnemy();
         
     }

     protected void FindClosestEnemy()
     { 
         float distanceClosestEnemy = Mathf.Infinity;
           
         foreach (Enemy currentEnemy in AllEnemies)
         { 
             float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
             if (distanceToEnemy < distanceClosestEnemy)
             {
                 distanceClosestEnemy = distanceToEnemy;

                 TargetEnemy = currentEnemy.gameObject;
             }
             
         }
         
         Debug.DrawLine(this.transform.position,TargetEnemy.transform.position,Color.blue);
            
     }
        
      protected void LookAtEnemy()
      {
          transform.LookAt(TargetEnemy.transform.position);
          
      }
      
      private IEnumerator BulletFire()
      {
          while (true)
          {
             ObjectPool.Instance.GetObjectFromPool(BulletCount, transform.position, Quaternion.identity);
             yield return new WaitForSeconds(_attackSpeed);
              
          }
        
      }
        
 }