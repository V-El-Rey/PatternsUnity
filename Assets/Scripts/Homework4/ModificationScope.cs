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

        public ModificationScope(IScope scope, Vector3 scopePosition)
        {
            _scopePosition = scopePosition;
            _scope = scope;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            var scope = Object.Instantiate(_scope.ScopeInstance, _scopePosition, Quaternion.identity);
            return weapon;
        }
    }
}

