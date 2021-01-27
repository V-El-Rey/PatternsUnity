using UnityEngine;

public interface IEnemyFactory
{
    GameObject Create(float hp, Vector3 position);
}
