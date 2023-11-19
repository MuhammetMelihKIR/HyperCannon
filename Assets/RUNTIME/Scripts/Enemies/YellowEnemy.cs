 using System;
 using Runtime.Scripts;
 using RUNTIME.Scripts.Interface;
 

 public class YellowEnemy : Enemy,IDamageableYellowBullet,IDamageableBlueBullet
 {
     public YellowBullet yellowBullet;
     public BlueBullet blueBullet;
     public void BlueBulletDamage()
     {
         HpCount -= blueBullet.damageCount;
         IncreaseHp();
     }
     public void YellowBulletDamage()
     {
         HpCount -= yellowBullet.damageCount;
         IncreaseHp();
     }
     private void IncreaseHp()
     {
         
         HpText.text = HpCount.ToString();
         if (HpCount<=0)
         {
             ObjectPool.Instance.ReturnObjectToPool(5,gameObject);
             ResetEnemyValues();
             OnEnemyDie?.Invoke();
         }
     }
    
     
     
     
 }
