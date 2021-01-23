using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : IMove
{
    private readonly ShipView _shipView = Object.FindObjectOfType<ShipView>().GetComponent<ShipView>();
    private readonly ShipModel _shipModel = new ShipModel();
    private Vector3 _move;

    public void Move(Vector3 direction, float shipSpeed)
    {
        var speed = shipSpeed * Time.deltaTime;
        _move.Set(direction.x * speed, direction.y * speed, 0.0f);
        _shipView.transform.position += _move;
    }
}
