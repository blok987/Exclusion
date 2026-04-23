using System.Drawing;
using UnityEngine;

public class SpallValues : MonoBehaviour
{
    public Vector3 CastOrigin;
    public Vector2 Size;

    LayerMask Collectible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContact())
        {
            Destroy(gameObject);
            Debug.Log("Player Contact");
        }
    }
    [HideInInspector]
    bool playerContact()
    {
        return Physics2D.BoxCast(transform.position + CastOrigin, Size, 0, Vector2.zero, Collectible);
    }
}
