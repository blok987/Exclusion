using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkScript : MonoBehaviour
{
    [SerializeField] float Acceleration = 10;
    [SerializeField] float Deceleration = 5;
    [SerializeField] float MaxSpeed = 10;
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


        
        if (Input.GetKey(KeyCode.D))//+X Move
        {
            if (isGrounded())
            {
                PlayerDirection.x += Acceleration * Time.deltaTime;
            }
            else
            {
                PlayerDirection.x += AirSpeed * Time.deltaTime;

            }
        }
        else if (Input.GetKey(KeyCode.A))//-X Move
        {
            if (isGrounded())
            {
                PlayerDirection.x -= Acceleration * Time.deltaTime;
            }
            else
            {
                PlayerDirection.x -= AirSpeed * Time.deltaTime;
            }
        }
        else //No X Input
        {
            if (isGrounded())
            {
                PlayerDirection.x = Mathf.Lerp(PlayerDirection.x, 0, Time.deltaTime * Deceleration) ;
            }
        }


        //Jump Move        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            PlayerDirection.y += JumpStrength;
        }
        
       PlayerDirection.x = Mathf.Clamp(PlayerDirection.x, -MaxSpeed, MaxSpeed);

        GetComponent <Rigidbody2D>().linearVelocity = PlayerDirection;
        #endregion
    }
    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayDistance, Ground);
    }
}
