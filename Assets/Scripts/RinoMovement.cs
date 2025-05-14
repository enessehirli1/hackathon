using UnityEngine;

public class RinoMovement : MonoBehaviour
{
    public float moveSpeed = 3f;          // Hareket hýzý
    public float patrolDistance = 10f;    // Toplam gidilecek mesafe

    private Vector3 startingPosition;
    private bool movingRight = true;

    void Start()
    {
        // Baþlangýç pozisyonu kaydediliyor
        startingPosition = transform.position;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Sað limite ulaþtý mý kontrol
            if (transform.position.x >= startingPosition.x + patrolDistance / 2f)
            {
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // Sol limite ulaþtý mý kontrol
            if (transform.position.x <= startingPosition.x - patrolDistance / 2f)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;  // Karakterin yüzünü ters çevir
        transform.localScale = scale;
    }
}
