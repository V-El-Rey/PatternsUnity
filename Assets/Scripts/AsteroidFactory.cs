using UnityEngine;

public class AsteroidFactory : IEnemyFactory
{
    private readonly AsteroidModel _asteroidModel = new AsteroidModel();
    
    public GameObject CreateAsteroid()
    {
        var enemy = Object.Instantiate(Resources.Load("Enemy/Asteroid") as GameObject);

        return enemy;
    }
}
