using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 0.1f;
    public float runSpeed = 0.2f;
    private Animator mAnimator;

    Vector2 moveInput;
    public bool IsMoving { get; private set; }

    Rigidbody2D rb;
    private float currentSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moveInput.x != 0)
        {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                // Shift bas�l� + A/D bas�l� -> Run
                currentSpeed = runSpeed;
                mAnimator.SetBool("IsRunning", true);
                mAnimator.SetBool("IsWalking", false);
            }
            else
            {
                // Sadece A/D -> Walk
                currentSpeed = walkSpeed;
                mAnimator.SetBool("IsWalking", true);
                mAnimator.SetBool("IsRunning", false);
            }
        }
        else
        {
            // Hi�bir input yok -> Idle
            currentSpeed = 0;
            mAnimator.SetBool("IsWalking", false);
            mAnimator.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * currentSpeed, rb.linearVelocity.y);
    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }
}
