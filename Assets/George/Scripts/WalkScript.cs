using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkScript : MonoBehaviour
{
    [SerializeField] float Acceleration = 10;
    [SerializeField] float Deceleration = 5;

    [SerializeField] float MaxSpeed = 10;
    [SerializeField] float AirSpeed = 5;

    [SerializeField] float JumpStrength = 5;
    [SerializeField] float ClimbSpeed = 3;

    

    public Vector2 PlayerDirection;
    public LayerMask Ground;
    public LayerMask Climbable;
    
    public float HalfBodyDistance = 1.1f;
    public float LArmlength = -1f;
    public float RArmlength = 1f;

    Animator dollAnim;
    SpriteRenderer dollRender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("This sensation! We need more!");
        print("Unity Engine. 500 hundered Monobehaviour Errors");

        dollAnim = GetComponent<Animator>();
        dollRender = GetComponent<SpriteRenderer>();
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
                dollAnim.SetBool("isRunning", true);
            }
            else
            {
                PlayerDirection.x += AirSpeed * Time.deltaTime;
                dollAnim.SetBool("isRunning", false);
                dollAnim.SetBool("isJumping", true);

            }
        }
        else if (Input.GetKey(KeyCode.A))//-X Move
        {
            if (isGrounded())
            {
                PlayerDirection.x -= Acceleration * Time.deltaTime;
                dollAnim.SetBool("isRunning", true);
            }
            else
            {
                PlayerDirection.x -= AirSpeed * Time.deltaTime;
                dollAnim.SetBool("isRunning", false);
                dollAnim.SetBool("isJumping", true);
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
            dollAnim.SetBool("isJumping", true);
        }

        //Climbing Movement 
        if (Input.GetKey(KeyCode.F))
        {
            if (isClimbingRight())
            {
                PlayerDirection.y += ClimbSpeed;
            }
            else if (isClimbingLeft())
            {
                PlayerDirection.y += ClimbSpeed;
            }
            
        }
        #endregion //ends y-axis movement handling


        GetComponent<Rigidbody2D>().linearVelocity = PlayerDirection;
        #endregion
    }
    


    //Methods for ground/Wall check
    private bool isGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, HalfBodyDistance, Ground);
    }
    
    private bool isClimbingLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, LArmlength, Climbable);
    }
    private bool isClimbingRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, RArmlength, Climbable);
    }
}
