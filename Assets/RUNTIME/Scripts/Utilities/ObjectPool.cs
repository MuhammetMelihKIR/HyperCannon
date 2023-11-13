using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;
        
        public GameObject[] objectPrefabs;
        public int poolSizePerObject ;

        private List<Queue<GameObject>> objectQueues;

        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            objectQueues = new List<Queue<GameObject>>();

            
            for (int i = 0; i < objectPrefabs.Length; i++)
            {
                Queue<GameObject> objectQueue = new Queue<GameObject>();
                for (int j = 0; j < poolSizePerObject; j++)
                {
                    GameObject obj = Instantiate(objectPrefabs[i]);
                    obj.SetActive(false);
                    objectQueue.Enqueue(obj);
                }
                objectQueues.Add(objectQueue);
            }
        }

        public GameObject GetObjectFromPool(int objectType, Vector3 position, Quaternion rotation)
        {
            if (objectType < 0 || objectType >= objectQueues.Count)
            {
                return null;
            }

            Queue<GameObject> objectQueue = objectQueues[objectType];

            if (objectQueue.Count == 0)
            {
                
                GameObject newObj = Instantiate(objectPrefabs[objectType], position, rotation);
                return newObj;
            }
            else
            {
                GameObject obj = objectQueue.Dequeue();
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                obj.transform.rotation=Quaternion.identity;
                return obj;
            }
        }

        public void ReturnObjectToPool(int objectType, GameObject obj)
        {
            if (objectType < 0 || objectType >= objectQueues.Count)
            {
                return;
            }
            obj.SetActive(false);
            objectQueues[objectType].Enqueue(obj);
            obj.transform.rotation=Quaternion.identity;
            
        }
        
    }
    
}