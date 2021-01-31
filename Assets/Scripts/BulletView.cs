using System;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        ReturnToPool();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Static Asteroid"))
        {
            ReturnToPool();
        }
    }
    
    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
