using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public int amountOfBullets;
    
    [SerializeField] private GameObject playerPrefab;
    private InputController _inputController;
    private PlayerController _playerController;
    private ObjectPool _objectPool;

    void Start()
    {
        ObjectPool.AmountToPool = amountOfBullets;
        var playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        _inputController = new InputController();
        _playerController = new PlayerController();
        
        _inputController.OnAccelerationActivation += _playerController.AccelerationOn;
        _inputController.OnAccelerationDeactivation += _playerController.AccelerationOff;
        _inputController.OnFireStart += _playerController.Fire;
        _playerController.OnPlayerGetTouched += _playerController.ApplyDamage;
        _objectPool = new ObjectPool();
        _objectPool.Initialize();
    }


    void Update()
    {
        _inputController.GetActionInput();
        _playerController.Update(_inputController.MoveDirection);
    }
}
