using System;
using Runtime.Scripts;
using RUNTIME.Scripts.Interface;
using UnityEngine;
public class RedBullet : Bullet
{
    public void UpdateDamage()
    {
        damageCount++;
    }
    private void OnTriggerEnter(Collider other)
    {
        RedBulletTrigger(other);
    }

    private void RedBulletTrigger(Collider other)
    {
        if (other.CompareTag("RedEnemy"))
        {
            IDamageableRedBullet damageableRedBullet = other.GetComponent<IDamageableRedBullet>();
            if (damageableRedBullet!=null)
            {
                damageableRedBullet.RedBulletDamage();
            }
            ObjectPool.Instance.ReturnObjectToPool(0,gameObject);
        }
       
        else if (other.CompareTag("Wall") || other.CompareTag("GameOver") || other.CompareTag("YellowEnemy") || other.CompareTag("BlueEnemy") || other.CompareTag("RedEnemy"))
        {
            ObjectPool.Instance.ReturnObjectToPool(0,gameObject);
        }
    }
}
