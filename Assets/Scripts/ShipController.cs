using UnityEngine;

public class ShipController : IMove, IFire
{

    private readonly ShipView _shipView = Object.FindObjectOfType<ShipView>();
    private readonly ShipModel _shipModel = new ShipModel();
    private readonly Rigidbody2D _shipRigidbody2D = Object.FindObjectOfType<ShipView>().GetComponent<Rigidbody2D>();
    

    public void Move(Vector2 direction, float shipSpeed)
    {
        var speed = shipSpeed * Time.deltaTime * direction;
        _shipRigidbody2D.velocity += speed;
    }

    public void Fire()
    {
        var temAmmunition = Object.Instantiate(_shipView.bullet, _shipView.barrel.position,
            _shipView.barrel.rotation);
        temAmmunition.AddForce(_shipView.barrel.up * _shipModel.Force);
    }

    public bool CollisionCheck()
    {
        return _shipView.isTouched;
    }
}
