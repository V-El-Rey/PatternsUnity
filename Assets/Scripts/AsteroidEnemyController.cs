using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class AsteroidEnemyController : IController
{
    private IEnemyFactory _asteroidEnemyFactory;
    private Transform _playerPosition;
    private float _spawnTime;
    private readonly List<GameObject> _asteroids = new List<GameObject>();


    private GameObject SpawnAsteroid(Vector3 distance)
    {
        return _asteroidEnemyFactory.Create(25.0f, distance);
    }

    private void DeleteAsteroid(GameObject go)
    {
        Object.Destroy(go);
    }

    private Vector3 GetDistanceToPlayer()
    {
        var randomVectorX = UnityEngine.Random.Range(-5.0f, 5.0f);
        var randomVectorY = UnityEngine.Random.Range(-5.0f, 5.0f);
        var randomVectorZ = 0.0f;

        var randomVector = new Vector3(randomVectorX, randomVectorY, randomVectorZ);

        var distance = _playerPosition.position + randomVector;

        return distance;
    }
    public void StartExecute()
    {
        _asteroidEnemyFactory = new AsteroidFactory();
        _playerPosition = Object.FindObjectOfType<ShipView>().transform;
        _spawnTime = 1000.0f;
    }

    public void UpdateExecute()
    {
        _spawnTime -= 0.5f;

        if (_spawnTime == 0.0f)
        {
            _asteroids.Add(SpawnAsteroid(GetDistanceToPlayer()));
            _spawnTime = 1000.0f;
        }

        if (_asteroids.Count == 5)
        {
            DeleteAsteroid(_asteroids[0]);
            _asteroids.Remove(_asteroids[0]);
        }

    }

    public void AwakeExecute()
    {
        
    }
}
