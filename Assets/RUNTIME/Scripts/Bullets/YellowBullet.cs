using UnityEngine;
using System;
using Runtime.Scripts;

public class YellowBullet : Bullet
 {
     public static Action OnYellowBulletTrigger;

     private void OnTriggerEnter(Collider other)
     {
         YellowBulletTrigger(other);
     }

     private void YellowBulletTrigger(Collider other)
     {
         if (other.CompareTag("YellowEnemy"))
         {
             OnYellowBulletTrigger?.Invoke();
             ObjectPool.Instance.ReturnObjectToPool(2,gameObject);
         }
        
         else 
         {
             ObjectPool.Instance.ReturnObjectToPool(2,gameObject);
         }
     }
        
 }
