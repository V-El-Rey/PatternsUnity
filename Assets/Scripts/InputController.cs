using UnityEngine;

public class InputController
{
    private Vector3 _moveDirection = new Vector3();
    private float _forward;
    private float _right;
    
    public delegate void Acceleration();

    public event Acceleration OnAccelerationActivation;
    public event Acceleration OnAccelerationDeactivation;

    public Vector3 MoveDirection => GetInput();
    

    private Vector3 GetInput()
    {
        _forward = Input.GetAxis("Vertical");
        _right = Input.GetAxis("Horizontal");
        _moveDirection.x = _right;
        _moveDirection.y = _forward;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnAccelerationActivation?.Invoke();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            OnAccelerationDeactivation?.Invoke();
        }
        
        return _moveDirection;
    }
}
