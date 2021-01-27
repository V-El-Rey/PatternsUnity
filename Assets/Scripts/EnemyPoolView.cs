using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolView
{
    private readonly Dictionary<int, EnemyPool> _viewCache = new Dictionary<int, EnemyPool>(12);

    public void Create(Vector3 distance, GameObject gameObject)
    {
        if (!_viewCache.TryGetValue(gameObject.GetInstanceID(), out EnemyPool viewPool))
        {
            viewPool = new EnemyPool(gameObject);
            _viewCache[gameObject.GetInstanceID()] = viewPool;
        }

        viewPool.Pop(distance);
    }

    public void Destroy(GameObject gameObject)
    {
        _viewCache[gameObject.GetInstanceID()].Push(gameObject);
    }
}
