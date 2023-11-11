using UnityEngine;
using System;
using Runtime.Scripts;
using RUNTIME.Scripts.Interface;

public class YellowBullet : Bullet
 {
    
     private void OnTriggerEnter(Collider other)
     {
         YellowBulletTrigger(other);
     }

     private void YellowBulletTrigger(Collider other)
     {
         if (other.CompareTag("YellowEnemy"))
         {
             IDamageableYellowBullet damageableYellowBullet = other.GetComponent<IDamageableYellowBullet>();
             if (damageableYellowBullet!=null)
             {
                 damageableYellowBullet.YellowBulletDamage();
             }
             ObjectPool.Instance.ReturnObjectToPool(2,gameObject);
         }
        
         else if (other.CompareTag("Wall") || other.CompareTag("GameOver") || other.CompareTag("YellowEnemy") || other.CompareTag("BlueEnemy") || other.CompareTag("RedEnemy"))
         {
             ObjectPool.Instance.ReturnObjectToPool(2,gameObject);
         }
     }
        
 }
