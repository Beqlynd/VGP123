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

    public bool getbuttondown;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius;

    public int maxLives = 5;
    private int _lives = 3;

    public int maxScore = 5;
    private int _score = 0;

    public int maxWeapons = 1;
    private int _weapon = 0;

    public int weaponCount;

    public int Lives
    {
        get { return _lives; }
        set
        {
            //if(_lives > value)

            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            //if (_lives < 0)
            //gameOver code

            Debug.Log("Lives have been set to " + _lives.ToString());
        }
    }
    
    /*Coroutine jumpForceChange;
    public int maxLives = 5;
    private int _lives = 3;

    private int _score = 0;

    public int maxWeapons = 1;
    private int _weapon = 0;

    public int lives
    {
        get { return _lives; }
        set
        {
            //if(_lives > value)

            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            //if (_lives < 0)
            //gameOver code

            Debug.Log("Lives have been set to " + _lives.ToString());
        }
    }*/

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            Debug.Log("Score has been set to " + _score.ToString());
        }
    }

    public int Weapon
    {
        get { return _weapon; }
        set
        {
            _weapon = value;

            if (_weapon > maxWeapons)
                _weapon = maxWeapons;
                        
        }
    }

    /*public void StartJumpForceChange()
    {
        if (jumpForceChange == null)
        {
            jumpForceChange = StartCoroutine(JumpForceChange());
        }
        else
        {
            StopCoroutine(jumpForceChange);
            JumpForceChange = null;
            jumpForce /= 2;
            JumpForceChange = StartCoroutine(JumpForceChange());
        }
    }

    IEnumerator JumpForceChange()
    {
        jumpForce *= 2;
        yield return new WaitForSeconds(5.0f);
        jumpForce /= 2;

        jumpForceChange = null;
    }*/

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
        AnimatorClipInfo[] curPlayingClip = anim.GetCurrentAnimatorClipInfo(0);
        float hInput = Input.GetAxisRaw("Horizontal");  //remove raw for transitionary speeds, look into downloadable input manager better than unity generic

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (curPlayingClip.Length > 0)
        {
            if (Input.GetButtonDown("Fire1") && curPlayingClip[0].clip.name != "Fire")
            {
                anim.SetTrigger("Fire");
            }
                
            else if (curPlayingClip[0].clip.name == "Fire")
                rb.velocity = Vector2.zero;
            else
            {
                Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
                rb.velocity = moveDirection;
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetButtonDown("Jump") && !isGrounded && curPlayingClip[0].clip.name != "Flap")
        {

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetTrigger("Flap");
        }

        anim.SetFloat("hInput", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);

        if (hInput != 0)
        {
            sr.flipX = (hInput < 0);
        }

        if (Input.GetButtonDown("Fire3") && _weapon == 1)
        {
            anim.SetTrigger("Smack");
        }
    }
}
