using UnityEngine;

public class PlayerController
{
    private readonly ShipController _ship = new ShipController();
    private readonly ShipModel _model = new ShipModel();


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
        _ship.Fire();
    }
}
