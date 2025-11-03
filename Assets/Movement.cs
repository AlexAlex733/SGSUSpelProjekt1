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

    // Update is called once per frame
    void Update()
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
            rb.linearVelocity = new Vector3(1, 0, 0);
            Debug.Log("right");
        }
        if(Input.GetKey(left))

        {
            rb.linearVelocity = new Vector3(-1, 0, 0);
            Debug.Log("left");
        }
        if(Input.GetKeyDown(Jump)&& isgrounded == true) 
        {
            
           rb.linearVelocity = new Vector3(0, 5, 0);

        }
       
    }
    
}
