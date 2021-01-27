using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEnemyView : MonoBehaviour
{
    public bool IsHitByBullet;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            IsHitByBullet = true;
        }
    }
}
