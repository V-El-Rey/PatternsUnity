using System.Collections;
using System.Collections.Generic;
using Homework4;
using UnityEngine;

namespace Homework4
{
     public class Scope : IScope
     {
          public Transform ScopePosition { get; }
          public GameObject ScopeInstance { get; }

          public Scope(Transform scopePosition, GameObject scopeInstance)
          {
               ScopeInstance = scopeInstance;
               ScopePosition = scopePosition;
          }
     }
}

