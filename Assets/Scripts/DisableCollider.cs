using UnityEngine;

public class DisableCollider : MonoBehaviour
{

    public GameObject sprite;
    
    public Collider2D col;

    // Update is called once per frame
    void Update()
    {
        if (sprite.activeSelf == false)
        {
            col.enabled = false;
        }
    }
}
