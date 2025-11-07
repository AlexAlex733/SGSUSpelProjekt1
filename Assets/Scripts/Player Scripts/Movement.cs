using System.Collections;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
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
        walkingSource.clip = walkingSound;
        jumpSource.clip = jumpSound;
        dashSource.clip = dashSound;
        walkingSource.loop = true;
        tr.emitting = false;
        rb = GetComponent<Rigidbody2D>(); // Hämtar Rigidbody2D-komponenten
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask);
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
     
    }

    private void Update()
    {
        if(horizontal != 0 && isGrounded)
        {
            walkingSource.enabled = true;
        }
        else if (horizontal == 0 || !isGrounded)
        {
            walkingSource.enabled = false;
        }

        if (isDashing)
        {
            return;
        }

        if (dashJumpBonusActive > 1)
        {
            dashJumpBonusActive = 1;
        }
        else if (dashJumpBonusActive < 0)
        {
            dashJumpBonusActive = 0;
        }

            Flip();


       if (Input.GetKeyDown(dash) && canDash)
        {
            StartCoroutine(Dash());
        }

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
                canJump = false;
            StartCoroutine(JumpCooldown());

        }
        if (isGrounded)
        {            
            jumpTimes = 1;
            canDash = true;
            dashJumpBonusActive = 0;
           
            
        }
        if (isDashing)
            {   
                canDash = false;
                isGrounded = false;
                dashJumpBonusActive = 1;
                
            }
        
    }

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

    IEnumerator DashJumpBonusWait()
    {
        yield return new WaitForEndOfFrame();
        dashJumpBonusActive = 1;
    }
    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}