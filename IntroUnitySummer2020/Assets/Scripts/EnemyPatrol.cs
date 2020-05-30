using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1.0f;
    public float chaseSpeed = 2.0f;
    public float detectionRadius = 2.0f;
    public float disengageRadius = 4.0f;

    private bool isFacingRight = true;
    private Vector2 facing = Vector2.right;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private GameObject chasee;

    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        currentSpeed = speed;
        chasee = null;
    }

    private GameObject AcquireTarget()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, detectionRadius, Vector2.right,
                  Mathf.Epsilon, LayerMask.GetMask("Player"));

        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    private void ChaseTarget()
    {
        Vector3 playerPosition = chasee.transform.position;
        Vector3 playerDir = playerPosition - transform.position;

        float dot = Vector3.Dot(Vector3.Normalize(playerDir), new Vector3(facing.x, facing.y, 0.0f));

        if (dot < 0.0f)
        {
            Flip();
        }
        currentSpeed = chaseSpeed;

        Debug.DrawLine(playerPosition, transform.position, Color.red);
    }

    private void ShouldDisengage()
    {
        float distance = Vector3.Distance(chasee.transform.position, transform.position);
        if (disengageRadius < distance)
        {
            chasee = null;
        }
    }

    private void FixedUpdate()
    {
        currentSpeed = speed;

        if (chasee == null)
        {
            GameObject target = AcquireTarget();

            if (target != null)
            {
                chasee = target;
                ChaseTarget();
            }
        }
        else
        {
            ChaseTarget();
            ShouldDisengage();
        }

        Vector2 currentPosition = rb.position;
        Vector2 newPosition = currentPosition + (facing * currentSpeed * Time.deltaTime);

        rb.MovePosition(newPosition);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        sprite.flipX = !sprite.flipX;

        if (isFacingRight)
        {
            facing = Vector2.right;
        }
        else
        {
            facing = Vector2.left;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Patrol"))
        {
            Flip();
            chasee = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1.0f, 0.0f, 0.0f, 0.2f);
        Handles.DrawSolidDisc(transform.position, Vector3.back, detectionRadius);
        Handles.color = new Color(0.0f, 1.0f, 0.0f, 0.2f);
        Handles.DrawSolidDisc(transform.position, Vector3.back, disengageRadius);
    }
}
