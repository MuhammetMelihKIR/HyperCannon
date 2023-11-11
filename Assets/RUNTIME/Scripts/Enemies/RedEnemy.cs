using Runtime.Scripts;
using RUNTIME.Scripts.Interface;
using UnityEngine;

public class RedEnemy :Enemy,IDamageableRedBullet,IDamageableBlueBullet
{ 
    private void OnEnable()
    {
        
        GameManager.OnLevelUpRedButton += LevelUp;
    }

    private void OnDisable()
    {
        GameManager.OnLevelUpRedButton -= LevelUp;
    }

    public void BlueBulletDamage()
    {
        IncreaseHp();
    }
    public void RedBulletDamage()
    {
        IncreaseHp();
    }
    private void IncreaseHp()
    {
        HpCount -= DamageCount; 
        HpText.text = HpCount.ToString();
        if (HpCount<=0)
        {
            ObjectPool.Instance.ReturnObjectToPool(3,gameObject);
            OnEnemyDie?.Invoke();
        }
    }
}
