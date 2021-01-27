using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    private InputController _inputController;
    private PlayerController _playerController;
    private AsteroidEnemyController _asteroidEnemyController;

    void Start()
    {
        var playerObject = Instantiate(Resources.Load<ShipView>("Player/Player"));
        _inputController = new InputController();
        _playerController = new PlayerController();
        _asteroidEnemyController = new AsteroidEnemyController();
        
        _inputController.OnAccelerationActivation += _playerController.AccelerationOn;
        _inputController.OnAccelerationDeactivation += _playerController.AccelerationOff;
        _inputController.OnFireStart += _playerController.Fire;
        _playerController.OnPlayerGetTouched += _playerController.ApplyDamage;
        
        _asteroidEnemyController.StartExecute();

    }


    void Update()
    {
        _inputController.GetActionInput();
        _playerController.UpdateExecute(_inputController.MoveDirection);
        _asteroidEnemyController.UpdateExecute();
    }
}
