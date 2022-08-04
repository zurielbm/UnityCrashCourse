using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolSpawning : MonoBehaviour
{
    public static PoolSpawning SharedInstance;
    public GameObject cube;
    public ObjectPool<GameObject> pool;
    bool collectionChecks = true;
    private int maxPoolSize = 10;
    
    private void Awake()
    {
        SharedInstance = this;
        pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10);
    }

    private GameObject CreatePooledItem()
    {
       
       GameObject instance = Instantiate(cube);
           return instance;
    }

    // Called when an item is returned to the pool using Release
    private void OnReturnedToPool(GameObject cube)
    {
       
        cube.SetActive(false);
        float xPos = Random.Range(-40.0f, 40.0f);
        float zPos = Random.Range(-40.0f, 40.0f);
  
        cube.transform.position = new Vector3(xPos, 1f, zPos);
    }

    // Called when an item is taken from the pool using Get
    private void OnTakeFromPool(GameObject cube)
    {
        cube.SetActive(true);
    }

    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    private void OnDestroyPoolObject(GameObject cube)
    {
        Destroy(cube);
    }

}
