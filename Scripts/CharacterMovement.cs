using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigi;
    private Animator anim;

    public float moveSpeed;
    public float jumpHeight;

    bool facingRight = true;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    public AudioSource audioSource;

    private bool doubleJump;

    // Use this for initialization
	void Start ()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        float move = Input.GetAxis("Horizontal");
        rigi.velocity = new Vector2
         (move * moveSpeed, rigi.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("vSpeed", rigi.velocity.y);
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    } 

	// Update is called once per frame
	void Update ()
    {
        if (grounded)
            doubleJump = false;
        anim.SetBool("Ground", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            audioSource.Play();
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
        {
            audioSource.Play();
            Jump();
            doubleJump = true;
        }
        //  if (Input.GetKey(KeyCode.D))
        // {
        //      rigi.velocity = new Vector2(moveSpeed,rigi.velocity.y);
        // }
        // if (Input.GetKey(KeyCode.A))
        //{
        //   rigi.velocity = new Vector2(-moveSpeed, rigi.velocity.y);
        //  }
        
    }
    void Jump()
    {
        rigi.velocity = new Vector2(rigi.velocity.x, jumpHeight);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
