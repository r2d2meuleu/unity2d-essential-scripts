using UnityEngine;
using Pixeye.Unity;

[RequireComponent(typeof(LineRender), typeof(Collider2D), typeof(Rigidbody2D))]
public class LineRenderPlayerMovement : MonoBehaviour
{
    [Foldout("Player Settings", true)]
    [SerializeField] float strenght = 10f;
    [SerializeField] float maxDistance = 15f; // Set a max distance, if the Line Renderer's lenght is higher than this value then the max force used will be calculated using this value instead

    [SerializeField] int minPower = -5;
    [SerializeField] int maxPower = 5;

    Vector2 minPowerV2;
    Vector2 maxPowerV2;

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Vector3 currentVelocity;
    Vector3 oppositeForce;

    bool applyForce;

    Camera cam;

    new Rigidbody2D rigidbody2D;

    public static LineRenderPlayerMovement instance;

    private void Awake()
    {
        instance = this;

        cam = Camera.main;

        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        minPowerV2 = new Vector2(minPower, minPower);
        maxPowerV2 = new Vector2(maxPower, maxPower);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody2D.velocity = Vector3.zero;

            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);         // Set the start position of the Line Renderer to be the current position of your cursor
            //startPoint = gameObject.transform.position;                     //Set the start position of the Line Rendere to be the center of the gameobjet

            startPoint.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;

            float distanceBetweenStartingPointToendPoint = Vector3.Distance(startPoint, currentPoint);     // Get the current distance between the starting point and the current point

            if (distanceBetweenStartingPointToendPoint >= maxDistance)
            {
                LineRender.instance.RenderLine(startPoint, currentPoint);
            }
            else
            {
                LineRender.instance.RenderLine(startPoint, currentPoint);
                force = new Vector2(Mathf.Clamp(startPoint.x - currentPoint.x, minPowerV2.x * 100, maxPowerV2.x * 100), Mathf.Clamp(startPoint.y - currentPoint.y, minPowerV2.y * 100, maxPowerV2.y * 100));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            applyForce = true;

            LineRender.instance.EndLine();
        }

        #region This code applies opposite force so that the impulse doesn't go on forever in case your gameobject gravity is set to zero, comment out if unnecessary
        currentVelocity = rigidbody2D.velocity;
        oppositeForce = -currentVelocity;
        rigidbody2D.AddRelativeForce(new Vector2(oppositeForce.x, oppositeForce.y));
        #endregion
    }

    private void FixedUpdate()
    {
        if (applyForce)
        {
            rigidbody2D.AddRelativeForce(new Vector3(force.x * strenght, force.y * strenght, 0), ForceMode2D.Impulse);
            applyForce = false;
        }
    }
}
