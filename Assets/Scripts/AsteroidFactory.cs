using UnityEngine;

public class AsteroidFactory : IEnemyFactory
{
    public Transform Position;
    
    
    
    public GameObject Create(float hp, Vector3 position)
    {

        var enemy = Object.Instantiate(Resources.Load("Enemy/Asteroid") as GameObject);
        enemy.transform.position = position;

        enemy.GetComponent<AsteroidEnemyView>().hp = hp;
        
        return enemy;
    }
}
