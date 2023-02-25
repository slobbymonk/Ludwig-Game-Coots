using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    public float jumpDelay;

    public Rigidbody2D rb;
    public Animator anim;
    public AudioManager audioManager;

    private bool canJump;

    public Vector2 lastSavedPosition;

    private Vector3 startingSize;
    public float turnTime;

    private void Awake()
    {
        startingSize = transform.localScale;
    }
    private void Start()
    {
        lastSavedPosition = transform.position;
    }

    void Update()
    {
        Movement();
        Jumping();

        if (transform.position.y < -20)
        {
            transform.position = lastSavedPosition;
            audioManager.Play("Reload");
        }
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
        //Make player face walking direction
        if (xMovement < 0 && transform.localScale.x > -startingSize.y)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-startingSize.x,
                transform.localScale.y, transform.localScale.z), turnTime * Time.deltaTime);
        }
        if (xMovement > 0 && transform.localScale.x < startingSize.y)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(startingSize.x,
                transform.localScale.y, transform.localScale.z), turnTime * Time.deltaTime);
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
        audioManager.Play("Jump");
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            canJump = true; 
            anim.SetBool("isInAir", false);
            lastSavedPosition = transform.position;
            audioManager.Play("Land");
        }
    }
}
