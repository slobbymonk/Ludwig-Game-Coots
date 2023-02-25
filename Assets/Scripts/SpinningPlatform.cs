using UnityEngine;

public class SpinningPlatform : MonoBehaviour
{
    public float rotationSpeed;
    private float rotation;

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localRotation.x,
                transform.localRotation.y, transform.localRotation.z + rotation);
        rotation += Time.deltaTime * rotationSpeed;
    }
}
