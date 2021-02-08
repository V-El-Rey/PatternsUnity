using UnityEngine;

public class PlayerController
{
    private readonly ShipController _ship;

    public PlayerController(ShipController shipController)
    {
        _ship = shipController;
    }
    
    private bool _flag = false;

    public delegate void Damage();

    public event Damage OnPlayerGetTouched;


    public void UpdateExecute(Vector3 direction)
    {
        _ship.Move(direction, _ship.ShipModel.Speed);
        if (_ship.CollisionCheck() == true)
        {
            if (_flag == false)
            {
                OnPlayerGetTouched?.Invoke();
                _flag = !_flag;
            }
        }
        else
        {
            _flag = false;
        }
    }

    public void AccelerationOn()
    {
        _ship.ShipModel.Speed += _ship.ShipModel.Acceleration;
    }

    public void AccelerationOff()
    {
        _ship.ShipModel.Speed -= _ship.ShipModel.Acceleration;
    }

    public void Fire()
    {
        _ship.Fire();
    }

    public void ApplyDamage()
    {
        if (_ship.ShipModel.Hp <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Dead");
        }
        else
        {
            _ship.ShipModel.Hp--;
        }
    }
}
