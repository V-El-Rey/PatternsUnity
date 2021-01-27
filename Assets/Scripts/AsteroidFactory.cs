using UnityEngine;

public class AsteroidFactory : IEnemyFactory
{
    public Transform Position;

    private readonly AsteroidModel _asteroidModel = new AsteroidModel();
    
    public GameObject CreateAsteroid(Vector3 position, GameObject prefab)
    {
        var enemy = Object.Instantiate(prefab);
        enemy.transform.position = position;

        return enemy;
    }

    public GameObject CreateAsteroid(Vector3 position, Vector3 heading)
    {
        var enemy = Object.Instantiate(Resources.Load("Enemy/Asteroid1") as GameObject);
        var enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
        enemy.transform.position = position;
        
        enemyRigidbody.AddForce(heading * AsteroidModel.Force, ForceMode2D.Impulse);

        return enemy;
    }
}
