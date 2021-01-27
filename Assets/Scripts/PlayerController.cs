using UnityEngine;

public class PlayerController : IPlayerController
{
    private readonly ShipController _ship = new ShipController();
    private readonly ShipModel _model = new ShipModel();
    private bool _flag = false;

    public delegate void Damage();

    public event Damage OnPlayerGetTouched;


    public void Update(Vector3 direction)
    {
        _ship.Move(direction, _model.Speed);
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

    public void ApplyDamage()
    {
        if (_model.Hp <= 0)
        {
            //Time.timeScale = 0;
            //Debug.Log("Dead");
        }
        else
        {
            _model.Hp--;
        }
    }

    public void UpdateExecute(Vector3 direction)
    {
        Update(direction);
    }

}
