using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public int amountOfBullets;
    
    private InputController _inputController;
    private PlayerController _playerController;
    //private AsteroidController _asteroidController;
    private EnemyShipsController _enemyShipsController;
    private ShipFactory _shipFactory;
    private ObjectPool _objectPool;
    
    [SerializeField] private List<ObjectPoolItem> gameObjectsNeedToPool;

    private void Start()
    {
        _objectPool = new ObjectPool();
        _shipFactory = new ShipFactory();
        _inputController = new InputController();
        _playerController = new PlayerController(_shipFactory.CreateAStarship("Player", Vector3.zero));
        //_asteroidController = new AsteroidController();
        _enemyShipsController = new EnemyShipsController(4);

        _inputController.OnAccelerationActivation += _playerController.AccelerationOn;
        _inputController.OnAccelerationDeactivation += _playerController.AccelerationOff;
        _inputController.OnFireStart += _playerController.Fire;
        _playerController.OnPlayerGetTouched += _playerController.ApplyDamage;

        _objectPool.Initialize(gameObjectsNeedToPool);
        //_asteroidController.Start();;
        _enemyShipsController.StartExecute();

    }


    private void Update()
    {
        
        _inputController.GetActionInput();
        _playerController.UpdateExecute(_inputController.MoveDirection);
        //_asteroidController.UpdateExecute();
        _enemyShipsController.UpdateExecute();

    }
}
