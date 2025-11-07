using System.Collections;

using UnityEngine;


public class Movement : MonoBehaviour
{
    // Different Variables for dashing - Alexander
    [SerializeField] float dashCooldown = 1;
    [SerializeField] bool canDash = true;
    [SerializeField] bool isDashing = false;
    [SerializeField] float dashTime = 0.2f;
    [SerializeField] float dashjumpBonus = 1.5f;
    [SerializeField, Range(0.0005f, 25)] float dashPower;
    [SerializeField] int dashJumpBonusActive = 1;



    [SerializeField] private float horizontal;
   
    public Transform groundCheckPoint; // Point from where the radius will be positioned
    public float groundCheckRadius = 0.2f; // Distance of the ground check
    public LayerMask groundMask; // Layer for ground objects
    [SerializeField] int jumpTimes = 1;
    
    [SerializeField] bool isGrounded;
    bool isFacingRight = true;
    [SerializeField, Range(0.0005f, 25)] float speed;
    [SerializeField, Range(0.0005f, 25)] float jumpForce;
    [SerializeField] float jumpCooldown = 0.4f;
    private bool canJump = true;
    [SerializeField] KeyCode Jump = KeyCode.Space;
    [SerializeField] KeyCode dash = KeyCode.LeftShift;
    private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    Animator animator;

    [SerializeField] AudioSource walkingSource;
    [SerializeField] AudioSource jumpSource;
    [SerializeField] AudioSource dashSource;

    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip dashSound;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walkingSource.clip = walkingSound; // Makes the sound work - Alexander
        jumpSource.clip = jumpSound;
        dashSource.clip = dashSound;
        walkingSource.loop = true;

        tr.emitting = false; // Makes it so there isn't a trail before you dash - Alexander
        rb = GetComponent<Rigidbody2D>(); // Gets the Rigidbody componenet - Alexander
    }


    private void FixedUpdate()
    {
        //Makes it so you can't do anything else while dashing - Alexander
        if (isDashing)
        {
            return;
        }
        // Gets player mvoement - Alexander
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask); //Groundcheck - Alexander
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
     
    }

    private void Update()
    {
        // Walk sounds while walking and not in the air - Alexander
        if(horizontal != 0 && isGrounded)
        {
            walkingSource.enabled = true;
        }
        else if (horizontal == 0 || !isGrounded)
        {
            walkingSource.enabled = false;
        }
        // If dashing can't do anything else - Alexander
        if (isDashing)
        {
            return;
        }
        // A variable inuse for the jump dash bonus - Alexander
        if (dashJumpBonusActive > 1)
        {
            dashJumpBonusActive = 1;
        }
        else if (dashJumpBonusActive < 0)
        {
            dashJumpBonusActive = 0;
        }

            Flip();

        // checks if you can dash and then lets you dash - Alexander
       if (Input.GetKeyDown(dash) && canDash)
        {
            StartCoroutine(Dash());
        }

       // checks if you can jump and whether you get the dash jump bonus or not
        if (Input.GetKeyDown(Jump) && jumpTimes > 0 && canJump)
        {
            jumpTimes -= 1;
            if (dashJumpBonusActive == 0)
            {
                jumpSource.Play();
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if (dashJumpBonusActive == 1)
            {
                jumpSource.Play();
                rb.AddForce(Vector2.up * jumpForce * dashjumpBonus, ForceMode2D.Impulse);
                dashJumpBonusActive = 0;
            }
            // Add a jump cooldown - Alexander
                canJump = false;
            StartCoroutine(JumpCooldown());

        }
        // Gives the player the dash back and jump back when you touch the ground - Alexander
        if (isGrounded)
        {            
            jumpTimes = 1;
            canDash = true;
            dashJumpBonusActive = 0;
           
            
        }
        // if you are dashing then you get the dash jump bonus and cant dash or jump.
        if (isDashing)
            {   
                canDash = false;
                isGrounded = false;
                dashJumpBonusActive = 1;
                
            }
        
    }

    //flips the player when they move - Alexander
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // alows the player to dash -  Alexander
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        transform.position += new Vector3 (0f, 0.02f, 0f);
        StartCoroutine(DashJumpBonusWait());
        dashSource.Play();
        rb.linearVelocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        
        

    }

    // makes it so you can get the dash jump bonus if you dashed ojn the ground - ALexander
    IEnumerator DashJumpBonusWait()
    {
        yield return new WaitForEndOfFrame();
        dashJumpBonusActive = 1;
    }

    // A jump cooldown for the player - Alexander
    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}