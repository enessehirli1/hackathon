using UnityEngine;

public class thorneDamages : MonoBehaviour
{
    public SimpleTimerBar timerBar; // Timer Bar scriptine referans
    public float damageAmount = 5f; // Eksilteceði süre

    private bool hasDamaged = false; // Çifte tetiklenmeleri önlemek için

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

            hasDamaged = true; // Tek seferlik hasar uygula (Ýstersen kaldýrabilirsin)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasDamaged = false; // Çýktýðýnda tekrar hasar alabilir hale gelir
        }
    }
}
