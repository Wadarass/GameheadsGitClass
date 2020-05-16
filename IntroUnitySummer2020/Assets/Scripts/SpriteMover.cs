using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteMover : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 2.0f;

    private Rigidbody2D rb;
    private float distanceToGround = 0.0f;
    private bool isJumping = false;
    private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Player layer and then change the mask to every layer but the player
        int maskValue = LayerMask.GetMask("Player");
        mask = ~maskValue;

        //Initialize the private variables to known values
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<CircleCollider2D>().radius + Mathf.Epsilon;
    }

    bool IsGrounded()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - distanceToGround), Vector2.down, 0.1f, mask);

        return (hit.collider != null);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            isJumping = true;
        }
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

        if (isJumping)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
