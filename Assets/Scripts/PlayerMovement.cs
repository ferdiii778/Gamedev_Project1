using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool isGrounded = true;
    private float moveDirection = 0f; // input dari UI
    private bool jumpPressed = false; // flag dari UI
    private bool attackPressed = false; // flag dari UI

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isRunning", false);
            return;
        }

        // Input dari keyboard
        float moveX = Input.GetAxisRaw("Horizontal");

        // Jika tidak ada input keyboard, pakai input dari tombol UI
        if (moveX == 0)
            moveX = moveDirection;

        // Gerak kiri-kanan
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Flip arah karakter
        if (moveX < 0)
            sr.flipX = true;
        else if (moveX > 0)
            sr.flipX = false;

        // Jalankan animasi lari jika di tanah
        bool isRunning = moveX != 0 && isGrounded;
        animator.SetBool("isRunning", isRunning);

        // Lompat: keyboard atau UI
        if ((Input.GetKeyDown(KeyCode.Space) || jumpPressed) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;

            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);

            jumpPressed = false; // reset setelah digunakan
        }

        // Serang: keyboard atau UI
        if (attackPressed)
        {
            animator.SetTrigger("attack");
            attackPressed = false; // reset agar tidak terus menyerang
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah menyentuh tanah
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    // Fungsi untuk UI Button
    public void MoveLeft() => moveDirection = -1f;
    public void MoveRight() => moveDirection = 1f;
    public void StopMove() => moveDirection = 0f;
    public void Jump() => jumpPressed = true;
    public void Attack() => attackPressed = true;
}
