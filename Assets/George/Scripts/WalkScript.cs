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

        #region Player X-Axis Movement
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
        else //Handles no X-axis Input
        {
            if (isGrounded())
            {
                //Handles the Deceleration of the Player when no input is given
                PlayerDirection.x = Mathf.Lerp(PlayerDirection.x, 0, Time.deltaTime * Deceleration) ;
            }
        }
        //Clamps the Player's X-Axis Speed to the MaxSpeed Variable
        PlayerDirection.x = Mathf.Clamp(PlayerDirection.x, -MaxSpeed, MaxSpeed);
        #endregion

        #region Player Y-Axis Movement
        //Jump Move        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            PlayerDirection.y += JumpStrength;
        }

        //Climbing Movement 

        #endregion //ends y-axis movement handling


        GetComponent<Rigidbody2D>().linearVelocity = PlayerDirection;
        #endregion //ends player movement handling
    }
    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayDistance, Ground);
    }
}
