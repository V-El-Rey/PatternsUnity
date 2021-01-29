using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private static List<GameObject> _pooledObjects;
    private static int _amountToPool;
    private GameObject _objectToPool;

    public static int AmountToPool
    {
        set => _amountToPool = value;
    }

    public void Initialize()
    {
        _pooledObjects = new List<GameObject>();
        for (int i = 0; i < _amountToPool; i++)
        {
            _objectToPool = Object.Instantiate(Resources.Load(("Bullet/Bullet")) as GameObject);
            _objectToPool.SetActive(false);
            _pooledObjects.Add(_objectToPool);
        }
    }

    public static GameObject GetObjectFromPool()
    {
        foreach (var t in _pooledObjects)
        {
            if (!t.activeInHierarchy)
            {
                return t;
            }
        }

        return null;
    }
}
