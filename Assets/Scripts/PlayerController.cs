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

    // Karakterin yönünü takip eden değişken
    public bool _isFacingRight = true;

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                // Yön değiştirildiğinde karakterin ölçeğini değiştir
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
            _isFacingRight = value;
        }
    }

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
                // Shift basılı + A/D basılı -> Koşma
                currentSpeed = runSpeed;
                mAnimator.SetBool("IsRunning", true);
                mAnimator.SetBool("IsWalking", false);
            }
            else
            {
                // Sadece A/D -> Yürüyüş
                currentSpeed = walkSpeed;
                mAnimator.SetBool("IsWalking", true);
                mAnimator.SetBool("IsRunning", false);
            }
        }
        else
        {
            // Hiçbir input yok -> Idle (Boşta)
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

        // Yön değiştirme fonksiyonunu çağır
        SetFacingDirection(moveInput);
    }

    // Yön değiştirme fonksiyonu
    public void SetFacingDirection(Vector2 direction)
    {
        if (direction.x > 0 && !_isFacingRight)
        {
            // Sağ yön -> Karakter sağa dönecek
            Flip();
        }
        else if (direction.x < 0 && _isFacingRight)
        {
            // Sol yön -> Karakter sola dönecek
            Flip();
        }
    }

    // Karakteri döndürme fonksiyonu
    public void Flip()
    {
        // Karakterin yerel skalasını x ekseninde ters çevir
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        _isFacingRight = !_isFacingRight; // Yönü değiştir
    }
}
