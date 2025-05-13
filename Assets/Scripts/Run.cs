using UnityEngine;

public class Run : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody2D rb;
    public float runSpeed = 10f;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Shift + D
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            mAnimator.SetBool("IsRunning", true);
        }
        // Shift + A
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            mAnimator.SetBool("IsRunning", true);
        }
        // Diğer durumlar
        else
        {
            mAnimator.SetBool("IsRunning", false);
        }
    }
}
