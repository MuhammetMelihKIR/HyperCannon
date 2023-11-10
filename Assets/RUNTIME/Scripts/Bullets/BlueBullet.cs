using System;
using Runtime.Scripts;
using UnityEngine;

public class BlueBullet : Bullet
{
   public static Action OnBlueBulletTrigger;

   private void OnTriggerEnter(Collider other)
   {
      BlueBulletTrigger(other);
   }

   private void BlueBulletTrigger(Collider other)
   {
      if (other.CompareTag("BlueEnemy"))
      {
         OnBlueBulletTrigger?.Invoke();
         ObjectPool.Instance.ReturnObjectToPool(1,gameObject);
      }
      else
      {
         ObjectPool.Instance.ReturnObjectToPool(1,gameObject);
      }
   }
}
