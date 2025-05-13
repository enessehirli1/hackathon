using UnityEngine;

public class AttackHitboxCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Enemy tag'ine sahip objeye çarptýysa
        {
            Debug.Log("Enemy Hit!");
            // Burada düþmana hasar verebilir veya baþka iþlemler yapabilirsiniz
            // collision.GetComponent<EnemyHealth>()?.TakeDamage(10);
        }
    }
}
