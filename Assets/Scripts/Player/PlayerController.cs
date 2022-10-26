using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))] //only 3 at a time
public class PlayerController : MonoBehaviour
{
    //I could be brown, I could be blue, I could be violet sky
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    public float speed;
    public float jumpForce;

    public float gravityScale;
    public float jumpCount;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius;
        
    // Start is called before the first frame update
    void Start()
    {
        //I could be purple, I could be hurtful, I could be anything you like
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
                
        //gotta be grean, gotta be mean, gotta be everything more


        if (speed <= 0)
        {
            speed = 1.5f;
            Debug.Log("speed not set - set to 1.5");
        }

        if (jumpForce <= 0)
        {
            jumpForce = 100;
            Debug.Log("jumpforce not set - set to 100");
        }

        if (gravityScale <= 0)
        {
            gravityScale = 0.3f;
            Debug.Log("gravity not set - set to 0.3");
        }

        if (!groundCheck)
        {
            groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
            Debug.Log("groundCheck not set - find it manually");
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.Log("ground check radius not set - Default to 0.2f");
        }

        //why don't you like me, why don't you like me, without making me try
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");  //remove raw for transitionary speeds, look into downloadable input manager better than unity generic

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            anim.ResetTrigger("kFlyAnim");
            anim.SetTrigger("kFlyAnim");
        }

        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            anim.ResetTrigger("kFlyAnim");
            anim.SetTrigger("kFlyAnim");
        }

        Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("hInput", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);

        if (hInput != 0)
        {
            sr.flipX = (hInput < 0);
        }
    }
}
