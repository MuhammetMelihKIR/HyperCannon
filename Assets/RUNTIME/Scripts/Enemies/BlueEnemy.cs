using UnityEngine;
using System;
using Runtime.Scripts;


public class BlueEnemy : Enemy
{
    private void OnEnable()
    {
        BlueBullet.OnBlueBulletTrigger += IncreaseHp;
        GameManager.OnLevelUpBlueButton += LevelUp;
    }

    private void OnDisable()
    {
        BlueBullet.OnBlueBulletTrigger -= IncreaseHp;
        GameManager.OnLevelUpBlueButton -= LevelUp;
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