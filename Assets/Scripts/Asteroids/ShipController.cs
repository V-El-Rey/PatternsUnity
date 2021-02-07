using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : IMove, IFire
{

    public readonly ShipView ShipView;
    public readonly ShipModel ShipModel;
    private Vector3 _move;


    public ShipController(ShipView view, ShipModel model)
    {
        ShipModel = model;
        ShipView = view;
    }

    public void Move(Vector3 direction, float shipSpeed)
    {
        var speed = shipSpeed * Time.deltaTime;
        _move.Set(direction.x * speed, direction.y * speed, 0.0f);
        ShipView.transform.position += _move;
    }

    public void Fire()
    {
        var bullet = ObjectPool.GetObjectFromPool("Bullet");
        if (bullet != null)
        {
            bullet.transform.position = ShipView.barrel.position;
            bullet.transform.rotation = ShipView.barrel.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(ShipModel.Force * Vector3.up,ForceMode2D.Impulse);
        }
    }

    public bool CollisionCheck()
    {
        return ShipView.isTouched;
    }
}
