using UnityEngine;

public class RinoMovement : MonoBehaviour
{
    public float moveSpeed = 3f;          // Hareket h�z�
    public float patrolDistance = 10f;    // Toplam gidilecek mesafe

    private Vector3 startingPosition;
    private bool movingRight = true;

    void Start()
    {
        // Ba�lang�� pozisyonu kaydediliyor
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

            // Sa� limite ula�t� m� kontrol
            if (transform.position.x >= startingPosition.x + patrolDistance / 2f)
            {
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            // Sol limite ula�t� m� kontrol
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
        scale.x *= -1;  // Karakterin y�z�n� ters �evir
        transform.localScale = scale;
    }
}
