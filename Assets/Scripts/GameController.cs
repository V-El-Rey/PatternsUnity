using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public int amountOfBullets;
    
    [SerializeField] private GameObject playerPrefab;
    private InputController _inputController;
    private PlayerController _playerController;
    private AsteroidController _asteroidController;
    private ObjectPool _objectPool;
    
    [SerializeField] private List<ObjectPoolItem> gameObjectsNeedToPool;

    void Start()
    {
        _objectPool = new ObjectPool();
        var playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        _inputController = new InputController();
        _playerController = new PlayerController();
        _asteroidController = new AsteroidController();
        
        _inputController.OnAccelerationActivation += _playerController.AccelerationOn;
        _inputController.OnAccelerationDeactivation += _playerController.AccelerationOff;
        _inputController.OnFireStart += _playerController.Fire;
        _playerController.OnPlayerGetTouched += _playerController.ApplyDamage;

        _objectPool.Initialize(gameObjectsNeedToPool);
        _asteroidController.Start();
        
    }


    void Update()
    {
        _asteroidController.UpdateExecute();
        _inputController.GetActionInput();
        _playerController.Update(_inputController.MoveDirection);
    }
}
