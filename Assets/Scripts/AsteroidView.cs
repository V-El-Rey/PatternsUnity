using UnityEngine;


public class AsteroidView : MonoBehaviour
{
    private bool _inSight = false;
    private const float TimeBeforeDestroy = 4.0f;

    public delegate void Hit(GameObject asteroid);

    public event Hit OnAsteroidIsHitByBullet;


    private void OnBecameVisible()
    {
        _inSight = true;
        CancelInvoke(nameof(ReturnToPool));
    }

    private void OnBecameInvisible()
    {
        if (!_inSight) return;
        Invoke(nameof(ReturnToPool), TimeBeforeDestroy);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            OnAsteroidIsHitByBullet?.Invoke(gameObject);
            PlayerController.score += 100;
            PlayerController.ApplyScore(PlayerController.score);
        }
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
