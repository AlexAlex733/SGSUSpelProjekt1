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
    [SerializeField] float dashjumpBonus = 1.2f;
    [SerializeField, Range(0.0005f, 25)] float dashPower;

    private float horizontal;
   
    public Transform groundCheckPoint; // Point from where the radius will be positioned
    public float groundCheckRadius = 0.2f; // Distance of the ground check
    public LayerMask groundMask; // Layer for ground objects
    [SerializeField] int jumpTimes = 1;
    
    bool isGrounded;
    bool isFacingRight = true;
    [SerializeField, Range(0.0005f, 25)] float speed;
    [SerializeField, Range(0.0005f, 25)] float jumpForce;
    [SerializeField] float jumpCooldown = 0.4f;
    private bool canJump = true;
    
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode Jump = KeyCode.Space;
    [SerializeField] KeyCode dash = KeyCode.LeftShift;
    private Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (isDashing)
        {
            return;
        }

        Flip();


      

        if (Input.GetKeyDown(Jump) && jumpTimes > 0 && canJump)
        {
            jumpTimes -= 1;
            if (canDash)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if (!canDash)
            {
                rb.AddForce(Vector2.up * jumpForce * dashjumpBonus, ForceMode2D.Impulse);
            }
                canJump = false;
            StartCoroutine(JumpCooldown());

        }
        if (isGrounded)
        {
            jumpTimes = 1;
            canDash = true;
        }
        if (Input.GetKeyDown(dash) && canDash)
        {
            StartCoroutine(Dash());
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
        rb.linearVelocity = new Vector2(transform.localScale.x * dashPower, 0f);
        //tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        //tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}