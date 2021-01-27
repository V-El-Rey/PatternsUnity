using UnityEngine;

public interface IEnemyFactory
{
    GameObject CreateAsteroid(Vector3 position, GameObject prefab);

    GameObject CreateAsteroid(Vector3 position, Vector3 heading);
}
