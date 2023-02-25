using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Vector2 offset;
    public float cameraMaxDistance = 20f;

    void Update()
    {
        Vector2 distance = (player.position - transform.position) * Time.deltaTime;
        distance /= cameraMaxDistance;

        transform.position += new Vector3(distance.x, distance.y, 0);
    }
}
