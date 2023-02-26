using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parralexEffectFactor;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * 1 - parralexEffectFactor);
        float distance = (cam.transform.position.x * parralexEffectFactor);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length*2)
        {
            startPos += length;
        }
        else if(temp <  startPos - length * 2)
        {
            startPos -= length;
        }
    }


}
