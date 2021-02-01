using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsController
{
    private List<EnemyController> _enemies;
    private ShipFactory _factory;
    private float _spawnTime = 400.0f;
    private Transform _playerPosition;
    
    public int NumberOfEnemies { get; set; }

    public EnemyShipsController(int numberOfEnemies)
    {
        NumberOfEnemies = numberOfEnemies;
    }

    public void StartExecute()
    {
        _enemies = new List<EnemyController>();
        _factory = new ShipFactory();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            var obj = _factory.CreateAStarship("Enemy Ship");
            _enemies.Add(new EnemyController(obj));
            obj.ShipView.gameObject.SetActive(false);
        }

        foreach (var item in _enemies)
        {
            item.StartExecute(_playerPosition);
        }
    }

    public void UpdateExecute()
    {
        _spawnTime -= 0.5f;
        
        if (_spawnTime == 0)
        {
            foreach (var item in _enemies)
            {
                if (!item.ShipController.ShipView.gameObject.activeInHierarchy)
                {
                    item.ShipController.ShipView.gameObject.SetActive(true);
                    item.ShipController.ShipView.gameObject.transform.position = GetRandomPosition();
                    item.ShipController.Move(_playerPosition.position - 
                                             item.ShipController.ShipView.gameObject.transform.position, 10.0f);
                    break;
                }
                else
                {
                    item.ShipController.Move(_playerPosition.position - 
                                             item.ShipController.ShipView.gameObject.transform.position, 10.0f);
                }
            }
            _spawnTime = 150.0f;
        }
        
    }

    private Vector3 GetRandomPosition()
    {
        var position = new Vector3 {x = Random.Range(-10.0f, 10.0f), y = _playerPosition.position.y + 12.0f, z = 0.0f};
        return position;
    }
}
