using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

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
    private bool isgrounded = true;

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
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundMask); // kollar om karaktären är på marken 
        if (isGrounded)
        {
            Debug.Log ("Grounded");
        }
        else
        {
           Debug.Log ("Not Grounded");
        }

        if (Input.GetKey(right))
        {
           rb.AddForce(Vector2.right  * speed, ForceMode2D.Force); // Gör så att våran karaktär kan röra på sig åt höger
            Debug.Log("right");
        }
        if(Input.GetKey(left))
        {
           rb.AddForce(Vector2.left * speed , ForceMode2D.Force); // Gör så att våran karaktär kan röra på sig åt vänster
            Debug.Log("left");
        }
       
       
    }
    
}
