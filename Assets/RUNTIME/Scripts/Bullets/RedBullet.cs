using System;
using Runtime.Scripts;
using UnityEngine;
public class RedBullet : Bullet
{
    public static Action OnRedBulletTrigger;

    private void OnTriggerEnter(Collider other)
    {
        RedBulletTrigger(other);
    }

    private void RedBulletTrigger(Collider other)
    {
        if (other.CompareTag("RedEnemy"))
        {
            OnRedBulletTrigger?.Invoke();
            ObjectPool.Instance.ReturnObjectToPool(0,gameObject);
        }
      
        else
        {
            ObjectPool.Instance.ReturnObjectToPool(0,gameObject);
        }
    }
}
