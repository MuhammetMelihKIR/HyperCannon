using Runtime.Scripts;
using UnityEngine;

public class RedEnemy :Enemy
{ 
    private void OnEnable()
    {
        RedBullet.OnRedBulletTrigger += IncreaseHp;
        GameManager.OnLevelUpRedButton += LevelUp;
    }

    private void OnDisable()
    {
        RedBullet.OnRedBulletTrigger -= IncreaseHp;
        GameManager.OnLevelUpRedButton -= LevelUp;
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
