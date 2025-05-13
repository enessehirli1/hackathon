using UnityEngine;

public class Jump : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody2D rb;
    public float jumpForce = 5f;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mAnimator.SetTrigger("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        
    }
}
