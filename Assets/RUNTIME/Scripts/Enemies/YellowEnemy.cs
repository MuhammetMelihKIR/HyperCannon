 using Runtime.Scripts;

 public class YellowEnemy : Enemy
 {
     private void OnEnable()
     {
         YellowBullet.OnYellowBulletTrigger += IncreaseHp;
         GameManager.OnLevelUpYellowButton += LevelUp;
     }

     private void OnDisable()
     {
         YellowBullet.OnYellowBulletTrigger -= IncreaseHp;
         GameManager.OnLevelUpYellowButton -= LevelUp;
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
