using UnityEngine;

public class AttackHitboxCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Enemy tag'ine sahip objeye �arpt�ysa
        {
            Debug.Log("Enemy Hit!");
            // Burada d��mana hasar verebilir veya ba�ka i�lemler yapabilirsiniz
            // collision.GetComponent<EnemyHealth>()?.TakeDamage(10);
        }
    }
}
