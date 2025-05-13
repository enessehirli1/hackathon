using UnityEngine;

public class Jump : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody2D rb;
    public float jumpForce = 5f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;  // Karakterin altına yerleştirilecek boş bir nesne
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;  // Zemin katmanını belirlemek için

    private bool isGrounded;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            mAnimator.SetTrigger("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Ground check alanını sahnede göstermek için
        if (groundCheck == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
