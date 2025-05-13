using UnityEngine;

public class Walk : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody2D rb;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Shift + D
        if (Input.GetKey(KeyCode.D))
        {
            mAnimator.SetBool("IsWalking", true);
        }
        // Shift + A
        else if (Input.GetKey(KeyCode.A))
        {
            mAnimator.SetBool("IsWalking", true);
        }
        // Diðer durumlar
        else
        {
            mAnimator.SetBool("IsWalking", false);
        }
    }
}
