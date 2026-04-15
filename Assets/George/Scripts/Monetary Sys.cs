using UnityEngine;
using UnityEngine.UIElements;

public class MonetarySys : MonoBehaviour

{
    [SerializeField] bool HasSpall;
    
    public int SpallValue;
    [SerializeField] int Spallet;
    
    public GameObject Spall;
    
    public LayerMask Player;
    public LayerMask Collectible;
    
    public Vector3 CastOrigin;

    public Vector2 Size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpallValue = 1;

    }
    private void Update()
    {
        if (playerContact())
        {
            Debug.Log("Player Contact");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    
    [HideInInspector] bool playerContact()
    {
        return Physics2D.BoxCast(transform.position + CastOrigin , Size, 0, Vector2.zero, Player);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + CastOrigin, Size);
    }

}
