using UnityEngine;

public class FollowBody : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;  
        }
    }
}
