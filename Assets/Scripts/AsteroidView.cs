using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AsteroidView : MonoBehaviour
{
    private bool _inSight = false;
    public bool isHitByBullet = false;

    public delegate void Hit(GameObject asteroid);

    public event Hit OnAsteroidIsHitByBullet;
    

    private void OnBecameVisible()
    {
        _inSight = true;
    }

    private void OnBecameInvisible()
    {
        if (_inSight)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            OnAsteroidIsHitByBullet?.Invoke(gameObject);
        }
    }
}
