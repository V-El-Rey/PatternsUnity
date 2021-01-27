using UnityEngine;

public class BulletView : MonoBehaviour
{
    public bool IsHitEnemy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish") != true) return;
        IsHitEnemy = true;
        Destroy(this.gameObject);
    }
}
