using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objToPool;
    public int amountToPool;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField] private List<ObjectPoolItem> objectsToPool;
    private List<GameObject> pool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pool = new List<GameObject>();

        foreach (ObjectPoolItem objectToPool in objectsToPool)
        {
            AddObjectToPool(objectToPool);
        }
    }

    private void AddObjectToPool(ObjectPoolItem newObjPool)
    {
        for (int i = 0; i < newObjPool.amountToPool; i++)
        {
            GameObject tmp = Instantiate(newObjPool.objToPool);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy && pool[i].CompareTag(tag))
            {
                return pool[i];
            }
        }

        return null;
    }
}
