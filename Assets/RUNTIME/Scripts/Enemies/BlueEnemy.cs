using UnityEngine;
using System;
using Runtime.Scripts;
using RUNTIME.Scripts.Interface;

public class BlueEnemy : Enemy,IDamageableBlueBullet
{
    public BlueBullet blueBullet;
    public void BlueBulletDamage()
    {
        IncreaseHp();
    }
    
    public void IncreaseHp()
    {
        HpCount -= blueBullet.damageCount;
        HpText.text = HpCount.ToString();
        if (HpCount<=0)
        {
            ObjectPool.Instance.ReturnObjectToPool(4,gameObject);
            ResetEnemyValues();
            OnEnemyDie?.Invoke();
        }
    }
}