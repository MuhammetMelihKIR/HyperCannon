 using Runtime.Scripts;
 using RUNTIME.Scripts.Interface;

 public class YellowEnemy : Enemy,IDamageableYellowBullet,IDamageableBlueBullet
 {
     private void OnEnable()
     {
         GameManager.OnLevelUpYellowButton += LevelUp;
     }

     private void OnDisable()
     {
         GameManager.OnLevelUpYellowButton -= LevelUp;
     }
     public void BlueBulletDamage()
     {
         IncreaseHp();
     }
     public void YellowBulletDamage()
     {
         IncreaseHp();
     }
     private void IncreaseHp()
     {
         HpCount -= DamageCount; 
         HpText.text = HpCount.ToString();
         if (HpCount<=0)
         {
             ObjectPool.Instance.ReturnObjectToPool(5,gameObject);
             OnEnemyDie?.Invoke();
         }
     }
     
     
 }
