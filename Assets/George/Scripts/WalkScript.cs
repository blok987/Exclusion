using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkScript : MonoBehaviour
{
    [SerializeField] float WalkSpeed = 10;
    [SerializeField] float AirSpeed = 5;
    [SerializeField] float JumpStrength = 5;
    
    public Vector2 PlayerDirection;
    public LayerMask Ground;

    public float rayDistance = 1.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        #region Player Movement Handling
        
        //Player Gravity
        PlayerDirection.y = GetComponent<Rigidbody2D>().linearVelocity.y;
        

        //+X Move
        if (Input.GetKey(KeyCode.D) && isGrounded()) 
        {
            PlayerDirection.x += WalkSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerDirection.x -= AirSpeed * Time.deltaTime;
        }

        //-X Move
        if (Input.GetKeyDown(KeyCode.A) && isGrounded())
        {
            PlayerDirection.x -= WalkSpeed * Time.deltaTime;
        }
        //-X Air Move
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerDirection.x += AirSpeed * Time.deltaTime;
        }
        
        //Jump Move        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            PlayerDirection.y += JumpStrength;
        }

        GetComponent <Rigidbody2D>().linearVelocity = PlayerDirection;
        #endregion
    }
    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayDistance, Ground);
    }
}
