using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 2.0f;

    private Rigidbody2D rb;
    private float distanceToGround = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, distanceToGround + 0.1f);
        // return (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon)
    }

// Update is called once per frame
void FixedUpdate()
    {
        float currentSpeed = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += speed;
        }

        rb.AddForce(new Vector2(currentSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);

        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }
}
