using System;
using Runtime.Scripts;
using RUNTIME.Scripts.Interface;
using UnityEngine;

public class BlueBullet : Bullet
{
   
   private void OnTriggerEnter(Collider other)
   {
      BlueBulletTrigger(other);
   }

   private void BlueBulletTrigger(Collider other)
   {
      if (other.CompareTag("BlueEnemy")|| other.CompareTag("RedEnemy") || other.CompareTag("YellowEnemy"))
      {
         IDamageableBlueBullet damageableBlueBullet = other.GetComponent<IDamageableBlueBullet>();
         if (damageableBlueBullet!=null)
         {
            damageableBlueBullet.BlueBulletDamage();
         }
         ObjectPool.Instance.ReturnObjectToPool(1,gameObject);
         
      }
      else if (other.CompareTag("Wall") || other.CompareTag("GameOver"))
      {
         ObjectPool.Instance.ReturnObjectToPool(1,gameObject);
      }
     
     
   }
}
