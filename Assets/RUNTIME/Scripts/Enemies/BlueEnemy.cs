using UnityEngine;
using System;
using Runtime.Scripts;
using RUNTIME.Scripts.Interface;

public class BlueEnemy : Enemy,IDamageableBlueBullet
{
    public BlueBullet blueBullet;
  

    private void Update()
    {
        if (GameManager.Instance.IsGameState(GameState.Win))
        {
            ObjectPool.Instance.ReturnObjectToPool(4,gameObject);
        }
        if (GameManager.Instance.IsGameState(GameState.Lose))
        {
            ObjectPool.Instance.ReturnObjectToPool(4,gameObject);
        }

    }
    
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