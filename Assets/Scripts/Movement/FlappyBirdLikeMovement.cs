using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class FlappyBirdLikeMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField] float strenght;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            rigidbody2D.centerOfMass = Vector2.zero;
            rigidbody2D.velocity = new Vector2(0, strenght);
        }
    }
}
