using System.Dynamic;
using UnityEngine;

public class AsteroidEnemyController : IController
{
    private IEnemyFactory _asteroidEnemyFactory;
    private Transform _playerPosition;
    private int _spawnTime;
    
    
    public void StartExecute()
    {
        _asteroidEnemyFactory = new AsteroidFactory();
        _playerPosition = Object.FindObjectOfType<ShipView>().transform;
        _spawnTime = 250;
    }

    public void UpdateExecute()
    {
        var time = Time.time + Time.deltaTime;
        if (time == _spawnTime)
        {
            var distance = _playerPosition.position + new Vector3(3.0f, 2.0f, 0.0f);
            _asteroidEnemyFactory.Create(25.0f, distance);
            time = 0.0f;
        }
    }

    public void AwakeExecute()
    {
        throw new System.NotImplementedException();
    }
}
