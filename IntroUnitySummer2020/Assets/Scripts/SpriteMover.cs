using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpriteMover : MonoBehaviour
{
    //Variables exposed to Unity Inspector
    public float speed = 5;
    public float jumpSpeed = 2.0f;

    //Local variables that I don't expose to the Unity inspector
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
        //Cast a ray from the bottom of the player collider to 0.1 units to find a collider.  
        //Searching in every layer but the layer that belongs to the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - distanceToGround), Vector2.down, 0.1f, mask);

        //If the collider isn't null that means we hit something.  We are grounded.
        return (hit.collider != null);
    }

    private void Update()
    {
        //If I hit space key and I'm grounded I'm jumping
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

        //If I'm jumping add the force.
        if (isJumping)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;   //Immediately stop jumping
        }
    }
}
