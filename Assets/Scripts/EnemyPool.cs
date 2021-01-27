using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool
{
    private readonly Stack<GameObject> _asteroidPool = new Stack<GameObject>(7);
    private readonly IEnemyFactory _factory = new AsteroidFactory();
    
    private readonly GameObject _prefab;

    public EnemyPool(GameObject prefab)
    {
        _prefab = prefab;
    }

    public int Counter;

    public void Push(GameObject go)
    {
        _asteroidPool.Push(go);
        go.SetActive(false);
    }

    public GameObject Pop(Vector3 distance)
    {
        GameObject go;
        if (_asteroidPool.Count == 0)
        {
            go = _factory.CreateAsteroid(distance, _prefab);
        }
        else
        {
            go = _asteroidPool.Pop();
        }
        go.SetActive(true);

        return go;
    }
}
