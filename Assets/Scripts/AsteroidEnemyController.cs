using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class AsteroidEnemyController : IController
{
    private Transform _playerPosition;
    private float _spawnTime;
    private EnemyPoolView _asteroids;
    private readonly GameObject _enemy = Resources.Load("Enemy/Asteroid") as GameObject;
    private AsteroidEnemyView _enemyView;
    
    private Vector3 GetDistanceToPlayer()
    {
        var randomVectorX = UnityEngine.Random.Range(-7.0f, 7.0f);
        var randomVectorY = UnityEngine.Random.Range(7.0f, 10.0f);
        var randomVectorZ = 0.0f;

        var randomVector = new Vector3(randomVectorX, randomVectorY, randomVectorZ);

        var distance = _playerPosition.position + randomVector;

        return distance;
    }
    public void StartExecute()
    {
        _enemyView = _enemy.GetComponent<AsteroidEnemyView>();
        _asteroids = new EnemyPoolView();
        _playerPosition = Object.FindObjectOfType<ShipView>().transform;
        _spawnTime = 1500.0f;
    }

    public void UpdateExecute()
    {
        _spawnTime -= 0.5f;

        if (_spawnTime != 0.0f) return;
        var distance = GetDistanceToPlayer();
        _asteroids.Create(distance, _enemy);
        _spawnTime = 750.0f;
        if (_enemyView.IsHitByBullet)
        {
            _asteroids.Destroy(_enemy);
        }

    }

    public void AwakeExecute()
    {
        
    }
}
