using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;

    //Input Keys 

    [SerializeField]private float speed = 9.0f;
    [SerializeField] private float jumpForce = 2.0f;

    [SerializeField] private KeyCode open;

    public bool facingRight = true;
    private Animator anim;

    //Jumping 
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        //Movement
        float hrz = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(hrz * speed, rBody.velocity.y);

        //Check if player is touching ground to jump
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        //jump
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
            isGrounded = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}