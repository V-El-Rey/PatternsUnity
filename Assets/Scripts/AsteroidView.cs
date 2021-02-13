using UnityEngine;


public class AsteroidView : MonoBehaviour
{
    private bool _inSight = false;
    private const float TimeBeforeDestroy = 4.0f;

    public delegate void Hit(GameObject asteroid);
    public delegate void Score();

    public event Hit OnAsteroidIsHitByBullet;
    public event Score OnAsteroidDestroyed;


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
            OnAsteroidDestroyed?.Invoke();
            OnAsteroidIsHitByBullet?.Invoke(gameObject);
        }
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
