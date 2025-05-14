using UnityEngine;

public class thorneDamages : MonoBehaviour
{
    public SimpleTimerBar timerBar; // Timer Bar scriptine referans
    public float damageAmount = 5f; // Eksiltece�i s�re

    private bool hasDamaged = false; // �ifte tetiklenmeleri �nlemek i�in

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasDamaged)
        {
            if (timerBar != null)
            {
                timerBar.currentTime -= damageAmount;
                if (timerBar.currentTime < 0)
                    timerBar.currentTime = 0;
            }

            hasDamaged = true; // Tek seferlik hasar uygula (�stersen kald�rabilirsin)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasDamaged = false; // ��kt���nda tekrar hasar alabilir hale gelir
        }
    }
}
