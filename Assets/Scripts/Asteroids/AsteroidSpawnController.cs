using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Camera;

public class AsteroidSpawnController
{
    private float _randomCoordinateInX;
    private float _randomCoordinateInY;

    private float _spawnTime = 350.0f;

    private Transform _playerPosition;

    public void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void UpdateExecute()
    {
        _spawnTime -= 0.5f;

        if (_spawnTime == 0.0f)
        {
            var spawnPosition = _playerPosition.position + GetCoordinates();
            var staticAsteroid = ObjectPool.GetObjectFromPool("Static Asteroid");
            if (staticAsteroid != null)
            {
                staticAsteroid.transform.position = spawnPosition;
                staticAsteroid.transform.rotation = Quaternion.identity;
                staticAsteroid.GetComponent<AsteroidView>().OnAsteroidIsHitByBullet += DestroyAsteroid;
                staticAsteroid.SetActive(true);
            }

            _spawnTime = 350.0f;
        }
    }
    
    private Vector3 GetCoordinates()
    {
        var position = _playerPosition.position;
        _randomCoordinateInX = Random.Range(-7.0f, 7.0f);
        _randomCoordinateInY = Random.Range(8.0f, 12.0f);
        return new Vector3(_randomCoordinateInX, _randomCoordinateInY, 0.0f);
    }

    private static void DestroyAsteroid(GameObject asteroid)
    {
        asteroid.SetActive(false);
        asteroid.GetComponent<AsteroidView>().OnAsteroidIsHitByBullet -= DestroyAsteroid;
    }
}
