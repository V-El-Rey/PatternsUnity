using UnityEngine;

public class InputController
{
    private Vector3 _moveDirection = new Vector3();
    private float _forward;
    private float _right;
    
    public delegate void Action();

    public event Action OnAccelerationActivation;
    public event Action OnAccelerationDeactivation;
    public event Action OnFireStart;

    public Vector3 MoveDirection => GetInput();
    

    private Vector3 GetInput()
    {
        _forward = Input.GetAxis("Vertical");
        _right = Input.GetAxis("Horizontal");
        
        _moveDirection.x = _right;
        _moveDirection.y = _forward;
        
        return _moveDirection;
    }

    public void GetActionInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnAccelerationActivation?.Invoke();
        }
                
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            OnAccelerationDeactivation?.Invoke();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            OnFireStart?.Invoke();
        }
    }
}
