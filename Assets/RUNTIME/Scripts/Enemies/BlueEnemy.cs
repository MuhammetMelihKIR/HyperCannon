using UnityEngine;
using System;
using Runtime.Scripts;
using RUNTIME.Scripts.Interface;

public class BlueEnemy : Enemy,IDamageableBlueBullet
{
    private void OnEnable()
    {
        GameManager.OnLevelUpBlueButton += LevelUp;
    }

    private void OnDisable()
    {
        GameManager.OnLevelUpBlueButton -= LevelUp;
    }
    
    public void BlueBulletDamage()
    {
        IncreaseHp();
    }
    
    private void IncreaseHp()
    {
        HpCount -= DamageCount; 
        HpText.text = HpCount.ToString();
        if (HpCount<=0)
        {
            ObjectPool.Instance.ReturnObjectToPool(4,gameObject);
            OnEnemyDie?.Invoke();
        }
    }
}