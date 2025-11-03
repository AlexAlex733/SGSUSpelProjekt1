using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public Transform groundCheckPoint; // Point from where the radius will be positioned
    public float groundCheckRadius = 0.2f; // Distance of the ground check
    public LayerMask groundMask; // Layer for ground objects
    public bool isGrounded;
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


    private void Update()
    {
        if (Input.GetKeyDown(Jump) && isGrounded == true)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump");

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask); // kollar om karaktären är på marken 
        Move(moveDirection);
    }
    void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * speed, rb.linearVelocity.y);
        float absoluteSpeed = Mathf.Abs(direction * speed);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask); // kollar om karaktären är på marken 

        if (Input.GetKey(right))
        {
            rb.AddForce(movement * speed, ForceMode2D.Force); // Gör så att våran karaktär kan röra på sig åt höger
     
        }
        if (Input.GetKey(left))
        {
            rb.AddForce(movement * speed, ForceMode2D.Force); // Gör så att våran karaktär kan röra på sig åt vänster
           
        }

    }
}