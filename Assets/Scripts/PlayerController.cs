using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    public float jumpDelay;

    public Rigidbody2D rb;
    public Animator anim;

    private bool canJump;

    void Update()
    {
        Movement();
        Jumping();
    }
    public void Movement()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float movementDisplacement = xMovement * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movementDisplacement, transform.position.y);

        if(xMovement> 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    public void Jumping()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            Invoke("Jump", jumpDelay);
        }
    }
    public void Jump()
    {
        rb.AddForce(jumpHeight * Vector2.up, ForceMode2D.Impulse);
        anim.SetBool("isInAir", true);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            canJump = true; 
            anim.SetBool("isInAir", false);
        }
    }
}
