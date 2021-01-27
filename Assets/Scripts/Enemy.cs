using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class Enemy
{
    public static GameObject CreateAsteroidEnemy(float hp)
    {
        var enemy = Object.Instantiate(Resources.Load("Enemy/Asteroid") as GameObject);

        enemy.GetComponent<AsteroidEnemyView>().hp = hp;
        
        return enemy;
    }
}
