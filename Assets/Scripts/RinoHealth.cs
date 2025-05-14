using UnityEngine;

public class RinoHealth : MonoBehaviour
{
    public int maxHealth = 10;            // Toplam can
    private int currentHealth;

    public Collider2D rinoCollider;       // Rino'nun Collider referansý (Polygon Collider 2D)
    public SimpleTimerBar timerBar;       // Timer referansý
    public float timeReward = 20f;        // Ödül olarak eklenecek zaman

    private bool isDead = false;

    private Rigidbody2D rb;               // Rigidbody2D referansý

    void Start()
    {
        currentHealth = maxHealth;

        if (rinoCollider == null)
            rinoCollider = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>(); // Rigidbody yoksa ekle ama Kinematic yap
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Dýþarýdan hasar verme fonksiyonu
    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;

        Debug.Log("Rino'ya vuruldu. Kalan can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (rinoCollider != null)
            rinoCollider.enabled = false; // Collider kapat

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Artýk düþsün
            rb.gravityScale = 3f; // Düþme hýzýný artýrabilirsin
        }

        if (timerBar != null)
            timerBar.currentTime += timeReward;

        Debug.Log("Rino öldü! Zaman + " + timeReward);
    }
}
