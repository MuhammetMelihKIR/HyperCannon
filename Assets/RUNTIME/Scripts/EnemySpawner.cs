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


    public float countdownTime; // Zamanlayıcı başlangıç süresi (saniye)
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        // Zamanlayıcıyı güncelle
        currentTime -= Time.deltaTime;

        // Zamanlayıcı sıfırlandığında
        if (currentTime <= 0)
        {
            // Zamanlayıcı bittiğinde yapılacak işlemleri buraya ekleyebilirsiniz
           
            SpawnEnemy();
            // Zamanlayıcıyı sıfırla veya durdur
            currentTime = 4f; // Zamanlayıcıyı sıfırlamak istiyorsanız
            // veya
            // currentTime = countdownTime; // Zamanlayıcıyı başlangıç değerine geri almak istiyorsanız
            // veya
            // Bu satırı kullanarak zamanlayıcıyı durdurabilirsiniz: currentTime = Mathf.Max(0f, currentTime);
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
