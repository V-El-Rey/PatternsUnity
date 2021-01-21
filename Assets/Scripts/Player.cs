using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        
        private MoveTransform _moveTransform;
        private Camera _camera;
        private Ship _ship;

        private void Start()
        {
            _camera = Camera.main;
            _moveTransform = new MoveTransform(transform, _speed);
            
        }

        private void Update()
        {
            _moveTransform.Move(Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"), Time.deltaTime);

            var direction = Input.mousePosition -
                            _camera.WorldToScreenPoint(transform.position);
            
            _moveTransform.Rotation(direction);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}
