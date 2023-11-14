using System.Collections;
using Runtime.Scripts;
using UnityEngine;

 public class Cannon : MonoBehaviour
 {
     protected GameObject TargetEnemy;
     protected Enemy[] AllEnemies;
     protected int BulletCount;
     private float _currentTime;

    
     private void FixedUpdate()
     {
         if (GameManager.Instance.gameState == GameState.InGame)
         {
             FindClosestEnemy();
             LookAtEnemy();
             SpawnBulletsTimer();
         }
         
     }
     private void FindClosestEnemy()
     { 
         float distanceClosestEnemy = Mathf.Infinity;
           
         foreach (Enemy currentEnemy in AllEnemies)
         { 
             
             float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
             if (distanceToEnemy < distanceClosestEnemy)
             {
                 distanceClosestEnemy = distanceToEnemy;

                 TargetEnemy = currentEnemy.gameObject;
                
             }

         }
         
        Debug.DrawLine(this.transform.position,TargetEnemy.transform.position,Color.blue);
            
     }
        
      private void LookAtEnemy()
      {
          transform.LookAt(TargetEnemy.transform.position);
          
      }

      private void SpawnBulletsTimer()
      {
          if (TargetEnemy.gameObject.activeSelf)
          {
             _currentTime -= Time.deltaTime;

              if (_currentTime <= 0)
              {
                  SpawnBullets();
                  _currentTime = 0.5f; 
              }
          }
      }

      private void SpawnBullets()
      {
          ObjectPool.Instance.GetObjectFromPool(BulletCount, transform.position, Quaternion.identity);
      }


     /*   private IEnumerator BulletFire()
      {
          while (true )
          {
              if (TargetEnemy.gameObject.activeSelf)
              {
                  ObjectPool.Instance.GetObjectFromPool(BulletCount, transform.position, Quaternion.identity);
                  yield return new WaitForSeconds(AttackSpeed);
              }
            
          }
     }
      */
 }