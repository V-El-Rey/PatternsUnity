using System.Collections;
using System.Collections.Generic;
using Homework4;
using UnityEngine;

namespace Homework4
{
    internal sealed class ModificationScope : ModificationWeapon
    {
        private readonly Vector3 _scopePosition;
        private readonly IScope _scope;
        private Weapon _previousWeaponState;

        public ModificationScope(IScope scope, Vector3 scopePosition)
        {
            _scopePosition = scopePosition;
            _scope = scope;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            SaveWeaponState(weapon);
            var scope = Object.Instantiate(_scope.ScopeInstance, _scopePosition, Quaternion.identity);
            return weapon;
        }

        protected override void SaveWeaponState(Weapon weapon)
        {
            _previousWeaponState = weapon;
        }

        public override Weapon RemoveModification(Weapon weapon)
        {
            return _previousWeaponState;
        }
    }
}

