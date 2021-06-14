using Pixeye.Unity;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider2D))]
public class GridbasedPlayerMovement : MonoBehaviour
{
    [Foldout("Player Settings", true)]
    [SerializeField] float speed = 5f;        // How long it takes the player from going to point A to point B.
    [SerializeField] Transform movePoint;     // Create an empty child gameObject to the player and move it 1f away.
    [SerializeField] LayerMask obstacleMask;  // Use this to prevent the player from going inside obstacles.

    new Rigidbody2D rigidbody2D;

    [SerializeField] bool useCustomSettings = true;

    void Start()
    {
        movePoint.parent = null;

        if (useCustomSettings)
        {
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigidbody2D.gravityScale = 0f;
        }
    }

    void Update()
    {
        float movementAmout = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
            }
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask))
        {
            movePoint.position = newPosition;
        }
    }
}

