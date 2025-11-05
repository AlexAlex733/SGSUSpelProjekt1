using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public Transform groundCheckPoint; // Point from where the radius will be positioned
    public float groundCheckRadius = 0.2f; // Distance of the ground check
    public LayerMask groundMask; // Layer for ground objects
    [SerializeField] int jumpTimes = 2;
    public bool isGrounded;
    public bool isFacingRight = true;
    [SerializeField, Range(0.0005f, 25)] float speed;
    [SerializeField, Range(0.0005f, 25)] float jumpForce;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode Jump = KeyCode.Space;
    private Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Hämtar Rigidbody2D-komponenten
    }


    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask);
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
     
    }

    private void Update()
    {
        Flip();


        if (isGrounded)
        {
            jumpTimes = 2;
        }

        if (Input.GetKeyDown(Jump) && jumpTimes > 0)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimes--;
           

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
}