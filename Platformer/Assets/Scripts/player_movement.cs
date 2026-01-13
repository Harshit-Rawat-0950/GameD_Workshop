using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    //private Animator anim;
    private bool grounded=false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");// Changes value depending on how long and how hard you press down the right or left arrow
        rb.linearVelocity = new Vector2(moveInput * 10f, rb.linearVelocity.y);
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            Jump(7f); // Jump with a force of 7
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
    private void Jump(float jumpForce){
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        grounded =false;// When you jump,you need ot set grounded to false to prevent errors
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
