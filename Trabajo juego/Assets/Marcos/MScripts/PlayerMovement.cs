using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb;
    private CapsuleCollider2D boxcolider2d;

    public LayerMask suelo;

    [SerializeField] public float fallVelocity;
    [SerializeField] public float dragMov;
    [SerializeField] public float dragStop;
    [SerializeField] public float jumpStrength;
    [SerializeField] private int vel;
    public void Start()
    {
        playerTransform = GetComponent<Transform>();
        boxcolider2d = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update() 
    {
        Movement();
        Jump();
    }
    private void Movement()
    {
        rb.drag = dragMov;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * vel, ForceMode2D.Force);
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                rb.velocityX = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                
                rb.AddForce(Vector2.right * vel, ForceMode2D.Force);
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    //rb.velocity.x = 0;
                    rb.velocityX -= 1;
                }
            }
            else //si no se mueve
            {
                rb.drag = dragStop;
            }
        }
    }
    private void Jump()
    {
        rb.mass = 4;
        rb.gravityScale = 1;
        if (Input.GetKeyDown(KeyCode.UpArrow) && BeOnGround())
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallVelocity;
            rb.mass += fallVelocity;
            if (rb.drag == dragStop)
            {
                rb.gravityScale += fallVelocity;
            }
        }
    }
    bool BeOnGround()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcolider2d.bounds.center, new Vector2(boxcolider2d.bounds.size.x, boxcolider2d.bounds.size.y), 0f, Vector2.down, 0.2f, suelo);
        return raycasthit.collider != null;
    }
}
