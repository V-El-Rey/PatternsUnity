using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class ObjectPool
{
    public List<GameObject> ObjectsInPool;

    public void AddObject(GameObject item)
    {
        var temporaryObject = Object.Instantiate(item);
        ObjectsInPool.Add(temporaryObject);
        temporaryObject.SetActive(false);
    }

    public void InitializePool(int count, GameObject sample)
    {
        ObjectsInPool = new List<GameObject>();
        
        for (int i = 0; i < count; i++)
        {
            AddObject(sample);
        }
    }
    
    public GameObject GetObject() 
    {
        for (int i = 0; i < ObjectsInPool.Count; i++) 
        {
            if (ObjectsInPool[i].gameObject.activeInHierarchy==false) {
                return ObjectsInPool[i];
            }
        }
        AddObject(ObjectsInPool[0]);
        
        return ObjectsInPool[ObjectsInPool.Count-1];
    }
}
