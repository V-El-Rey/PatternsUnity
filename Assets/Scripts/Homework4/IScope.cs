using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework4
{
  public interface IScope
  {
    Transform ScopePosition { get; }
    GameObject ScopeInstance { get; }
  
  }
}
