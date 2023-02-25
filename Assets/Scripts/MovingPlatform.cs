using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector2 startPosition;
    public float pingPongDistance;
    public float initialDistance;
    public float moveSpeed;

    private bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y + initialDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > startPosition.y + pingPongDistance)
        {
            goingUp = false;
        }
        if (transform.position.y < startPosition.y - pingPongDistance)
        {
            goingUp = true;
        }
        float moveDistance = moveSpeed * Time.deltaTime;
        if (goingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveDistance);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveDistance);
        }
    }
}
