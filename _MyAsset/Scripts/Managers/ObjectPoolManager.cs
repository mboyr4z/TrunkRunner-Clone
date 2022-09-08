using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    [System.Serializable]
    public class Pool
    {
        public PoolingObjectsTag tag;
        public GameObject prefab;
        public int size;
    }

    public Dictionary<PoolingObjectsTag, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;
    private void Start()
    {
        poolDictionary = new Dictionary<PoolingObjectsTag, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }


   
    public GameObject SpawnFromPool(PoolingObjectsTag tag, Vector3 pos, Quaternion rot)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool has contain this tag");
            return null;
        }

        if(poolDictionary[tag].Count == 0)
        {
            foreach (Pool pool in pools)
            {
                if(pool.tag == tag)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    obj.transform.SetParent(transform);
                    poolDictionary[tag].Enqueue(obj);
                }
            }
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;


        return objectToSpawn;
    }

    public void CollectToPool(PoolingObjectsTag tag, GameObject obj)
    {
        obj.transform.parent = transform;
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }
}

public enum PoolingObjectsTag
{
    diamond,
    blueDiamond
}