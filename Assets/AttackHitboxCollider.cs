using UnityEngine;

public class AttackHitboxCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Enemy tag'ine sahip objeye çarptýysa
        {
            Debug.Log("Enemy Hit!");

            // RinoHealth component'ini al ve hasar ver
            RinoHealth rino = collision.GetComponent<RinoHealth>();
            if (rino != null)
            {
                rino.TakeDamage(1);
            }

            SpiritHealth spirit = collision.GetComponent<SpiritHealth>();
            if (spirit != null)
            {
                spirit.TakeDamage(1);
            }
        }
    }
}
