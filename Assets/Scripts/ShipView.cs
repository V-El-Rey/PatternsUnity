using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipView : MonoBehaviour
{
    public Transform barrel;
    public Rigidbody2D bullet;

    [FormerlySerializedAs("IsTouched")] public bool isTouched = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            isTouched = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isTouched = false;
    }
}
