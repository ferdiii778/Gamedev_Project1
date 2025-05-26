using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); // Tambahkan SpriteRenderer
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Hentikan gerak horizontal
            animator.SetBool("isRunning", false);       // Hentikan animasi lari
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");

        // Gerak kiri-kanan
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Flip arah karakter
        if (moveX < 0)
            sr.flipX = true;
        else if (moveX > 0)
            sr.flipX = false;

        // Animasi jalan
        animator.SetBool("isRunning", moveX != 0);

        // Lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek sentuh tanah
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
