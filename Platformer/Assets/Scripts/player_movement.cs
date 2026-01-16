using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    //private Animator anim;
    private bool grounded = false;
    bool colliding;
    [SerializeField] float moveSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] float JumpForce;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveInput;
        moveInput = Input.GetAxis("Horizontal");// Changes value depending on how long and how hard you press down the right or left arrow
        if (!colliding)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
        else if (colliding && moveInput != 0 && !grounded)
        {
            Debug.Log(colliding);
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, -slideSpeed);
        }
        else
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            Jump(JumpForce); // Jump with a force of 7
        }
        if (moveInput > 0f)
        {
            transform.localScale = new Vector3(10f, 8.5f, 1f);// Turn player to right
        }
        else if (moveInput < 0f)
        {
            transform.localScale = new Vector3(-10f, 8.5f, 1f);// Turn player to left
        }
    }
    private void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        grounded = false;// When you jump,you need ot set grounded to false to prevent errors
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("IsGrounded");
            grounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            colliding = true;
        }
    }
}
