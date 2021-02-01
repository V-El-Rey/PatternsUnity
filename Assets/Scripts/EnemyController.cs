using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public readonly ShipController ShipController;
    private Vector3 _move;
    private Transform _playerPosition;
    [SerializeField] private bool _startChase = false;

    public EnemyController(ShipController ship)
    {
        ShipController = ship;
    }

    public void StartExecute(Transform position)
    {
        _playerPosition = position;
    }
}
