using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;
    [SerializeField] private Transform _pos3;
   
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
        
        ObjectPool.Instance.GetObjectFromPool(objectCount1, _pos1.position, Quaternion.identity);
        ObjectPool.Instance.GetObjectFromPool(objectCount2, _pos2.position, Quaternion.identity);
        ObjectPool.Instance.GetObjectFromPool(objectCount3, _pos3.position, Quaternion.identity);
        
    }
    
}
