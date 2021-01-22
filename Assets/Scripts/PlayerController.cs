using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private readonly ShipController _ship = new ShipController();

    private Camera _camera;

    public void Update(Vector3 direction)
    {
        _camera = Camera.main;
        _ship.Move(direction);
    }
}
