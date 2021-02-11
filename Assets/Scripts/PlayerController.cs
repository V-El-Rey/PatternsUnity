using UnityEngine;
using UnityEngine.UI;

public class PlayerController
{
    private static ShipController _ship;

    public PlayerController(ShipController shipController)
    {
        _ship = shipController;
    }
    
    private bool _flag = false;

    public string scoreToString;

    public delegate void Damage();

    public event Damage OnPlayerGetTouched;

    public static int score;


    public void StartExecute()
    {
        _ship.ShipModel.Score = score;
    }

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

    public static void ApplyScore(int score)
    {
        _ship.ShipView.gameObject.GetComponentInChildren<Text>().text = ScoreInterpreter.InterpretateScore(score);
    }
}
