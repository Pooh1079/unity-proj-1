using UnityEngine;

public class PlayerContoler : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    /*
    private void Awake()
    {
        transform.position = new Vector3(-15.53f, -0.8f, 0);
    }
    */
    public Vector3 startPosition = new Vector3(-15.53f, -0.8f, 0);

    private void Awake()
    {      
        transform.position = startPosition;
    }

    private void Start()
    {
        //transform.position = new Vector3(-15.53, transform.position.y, transform.position.z);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput == 0)
        {            
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOF");
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
}




