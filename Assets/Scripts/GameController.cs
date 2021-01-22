using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [FormerlySerializedAs("_playerPrefab")] [SerializeField] private GameObject playerPrefab;
    private InputController _inputController;
    private PlayerController _playerController;
    private Vector3 debugposition;

    void Start()
    {
        var playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        _inputController = new InputController();
        _playerController = new PlayerController();
    }

    
    void Update()
    {
        _playerController.Update(_inputController.MoveDirection);
    }
}
