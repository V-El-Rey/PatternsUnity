using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Homework4
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private Weapon _previousWeaponState;
        public ModificationMuffler(AudioSource audioSource, IMuffler muffler,
            Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            SaveWeaponState(weapon);
            var muffler = Object.Instantiate(_muffler.MufflerInstance,
                _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }
        
        protected override void SaveWeaponState(Weapon weapon)
        {
            _previousWeaponState = weapon;
        }

        public override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_muffler.MufflerInstance.gameObject);
            return _previousWeaponState;
        }
    }

}