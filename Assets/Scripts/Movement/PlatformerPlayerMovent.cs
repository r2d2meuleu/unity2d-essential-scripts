using UnityEngine;
using Pixeye.Unity;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlatformerPlayerMovent : MonoBehaviour
{
    [Foldout("Player Movement", true)]
    [SerializeField] float moveSpeed = 10f; //Player movement speed
    [SerializeField] float jumpForce = 10f; //Impulse to apply on KeyCode press
    [SerializeField] float jumpTime = 0f; //Airborne time
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    float jumpTimeCounter;
    bool stoppedJumping;
    bool canDoubleJump;

    float xMovement;

    bool grounded;

    [Foldout("Ground Checker", true)]
    [SerializeField] LayerMask whatIsGround; //Apply the layer you use to identify the ground on which you can jump on
    [SerializeField] Transform groundCheck; // Create a child gameobject to your player on move it to the bottom
    [SerializeField] float groundCheckRadius = 0.05f; // Ground check tollerance

    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        xMovement = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                stoppedJumping = false;
            }

            if (!grounded && canDoubleJump)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                stoppedJumping = false;
                canDoubleJump = false;
            }
        }

        if (Input.GetKey(jumpKey) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(jumpKey))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(xMovement * moveSpeed, rigidbody2D.velocity.y);
    }
}
