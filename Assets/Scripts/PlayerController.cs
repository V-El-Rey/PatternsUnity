using UnityEngine;

public class PlayerController
{
    private readonly ShipController _ship = new ShipController();
    private readonly ShipModel _model = new ShipModel();
    private readonly ShipView _view = GameObject.FindObjectOfType<ShipView>().GetComponent<ShipView>();
    

    public void Update(Vector3 direction)
    {
        _ship.Move(direction, _model.Speed);
    }

    public void AccelerationOn()
    {
        _model.Speed += _model.Acceleration;
    }

    public void AccelerationOff()
    {
        _model.Speed -= _model.Acceleration;
    }

    public void Fire()
    {
        var temAmmunition = GameObject.Instantiate(_view.bullet, _view.barrel.position, _view.barrel.rotation);
        temAmmunition.AddForce(_view.barrel.up * _model.Force);
    }
}
