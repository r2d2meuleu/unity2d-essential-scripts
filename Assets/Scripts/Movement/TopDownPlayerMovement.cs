using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class TopDownPlayerMovement : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;

    float xMovement;
    float yMovement;

    [SerializeField] bool useCustomSettings;

    new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (useCustomSettings)
        {
            rigidbody2D.gravityScale = 0;
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(xMovement * moveForce, yMovement * moveForce);
    }
}