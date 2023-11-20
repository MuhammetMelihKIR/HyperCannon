using Runtime.Scripts;
using RUNTIME.Scripts.Interface;
using UnityEngine;

public class RedEnemy :Enemy,IDamageableRedBullet,IDamageableBlueBullet
{
    public RedBullet redBullet;
    public BlueBullet blueBullet;
    
   
    private void Update()
    {
        if (GameManager.Instance.IsGameState(GameState.Win))
        {
            ObjectPool.Instance.ReturnObjectToPool(3,gameObject);
        }
        if (GameManager.Instance.IsGameState(GameState.Lose))
        {
            ObjectPool.Instance.ReturnObjectToPool(3,gameObject);
        }
    }
    
    public void BlueBulletDamage()
    {
        HpCount -= blueBullet.damageCount; 
        IncreaseHp();
    }
    public void RedBulletDamage()
    {
        HpCount -= redBullet.damageCount; 
        IncreaseHp();
    }
    private void IncreaseHp()
    {
        HpText.text = HpCount.ToString();
        if (HpCount<=0)
        {
            ObjectPool.Instance.ReturnObjectToPool(3,gameObject);
            ResetEnemyValues();
            OnEnemyDie?.Invoke();
        }
    }
    
}
