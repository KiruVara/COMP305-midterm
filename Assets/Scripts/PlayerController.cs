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

    //animation ducking
    private bool isDucking = false;

    //for chest
    public OpenChest oc;
    public bool opened = false; 

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
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            facingRight = true;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            facingRight = false;
        }
        else
            rBody.velocity = new Vector2(0, rBody.velocity.y);

        //Make sure character flips for animations
        if (facingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //check if ducking
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            isDucking = true;

        }
        else
            isDucking = false;
        //animation variables
        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDucking", isDucking);
    }

    //open chest
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Chest") && Input.GetKey(open) && opened == false)
        {
            oc.Open();
            opened = true; 
        }

    }
}
