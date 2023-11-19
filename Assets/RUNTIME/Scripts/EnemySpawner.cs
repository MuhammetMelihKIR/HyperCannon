
using Runtime.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform Pos1;
    [SerializeField] private Transform Pos2;
    [SerializeField] private Transform Pos3;
   
    private float _currentTime;

    
    void Update()
    {
        if (GameManager.Instance.IsGameState(GameState.InGame))
        {
             _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                SpawnEnemy();
                _currentTime = 4f;
            }
        }
    }
    

    private void SpawnEnemy()
    {
        int objectCount1 = Random.Range(3, 6); 
        int objectCount2= Random.Range(3, 6); 
        int objectCount3 = Random.Range(3, 6); 
        
        ObjectPool.Instance.GetObjectFromPool(objectCount1, Pos1.position, Quaternion.identity);
        ObjectPool.Instance.GetObjectFromPool(objectCount2, Pos2.position, Quaternion.identity);
        ObjectPool.Instance.GetObjectFromPool(objectCount3, Pos3.position, Quaternion.identity);
        
    }
    
}
