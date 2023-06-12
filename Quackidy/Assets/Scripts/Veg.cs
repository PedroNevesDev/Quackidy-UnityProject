using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veg : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.SlowDown();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.StopSlow();
    }
}
