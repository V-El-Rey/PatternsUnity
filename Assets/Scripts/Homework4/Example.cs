using UnityEngine;

namespace Homework4
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;
        [Header("ScopeGun")] 
        [SerializeField] private Transform _scopePosition;
        [SerializeField] private GameObject _scope;
         
        private Weapon _weapon;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            Weapon _weapon = new Weapon(ammunition, _barrelPosition, 999.0f,
                _audioSource, _audioClip);
            // Muffler muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
            //      _barrelPosition, _muffler);
            // ModificationWeapon modificationWeapon = new
            //      ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            // modificationWeapon.ApplyModification(_weapon);
            _fire = _weapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
                    _barrelPosition, _muffler);
                ModificationWeapon modificationWeapon = new
                    ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
                modificationWeapon.ApplyModification(_weapon);
                _fire = modificationWeapon;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                var scope = new Scope(_scopePosition, _scope);
                ModificationWeapon modificationWeapon = new ModificationScope(scope, _scopePosition.position);
                modificationWeapon.ApplyModification(_weapon);
                _fire = modificationWeapon;
            }
        }
    }
}