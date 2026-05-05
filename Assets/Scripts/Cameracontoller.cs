using UnityEngine;

public class Cameracontoller : MonoBehaviour
{
    public GameObject target;
    public float speed = 3f;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.fixedDeltaTime * speed);
    }
}
