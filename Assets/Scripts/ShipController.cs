using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : IMove, IFire
{

    private readonly ShipView _shipView = Object.FindObjectOfType<ShipView>();
    private readonly ShipModel _shipModel = new ShipModel();
    private Vector3 _move;
    

    public void Move(Vector3 direction, float shipSpeed)
    {
        var speed = shipSpeed * Time.deltaTime;
        _move.Set(direction.x * speed, direction.y * speed, 0.0f);
        _shipView.transform.position += _move;
    }

    public void Fire()
    {
        var bullet = ObjectPool.GetObjectFromPool();
        if (bullet != null)
        {
            bullet.transform.position = _shipView.barrel.position;
            bullet.transform.rotation = _shipView.barrel.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(_shipModel.Force * Vector3.up,ForceMode2D.Impulse);
        }
    }

    public bool CollisionCheck()
    {
        return _shipView.isTouched;
    }
}
