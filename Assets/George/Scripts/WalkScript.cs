using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

[RequireComponent(typeof(Rigidbody2D))]
public class WalkScript : MonoBehaviour
{
    [SerializeField] float Acceleration = 10;
    [SerializeField] float Deceleration = 5;

    [SerializeField] float MaxSpeed = 10;
    [SerializeField] float MaxVerticalSpeed = 8;
    [SerializeField] float AirSpeed = 5;

    [SerializeField] float JumpStrength = 5;
    [SerializeField] float ClimbSpeed = 1;

    [SerializeField] bool isJumping = false;
    public bool isRunning = false;
    public bool canMove = true;

    public Vector2 PlayerDirection;
    //Offsets for the raycasts to check for ground and climbable walls
    public Vector2 GroundOffset;
    public Vector2 LOffset;
    public Vector2 ROffset;

    //Layermasks for Player Ground and Climbable Wall checks
    public LayerMask Ground;
    public LayerMask Climbable;

    //Raycasts lengths for ground and wall checks
    public float HalfBodyDistance = 1.1f;
    public float LArmlength = -1f;
    public float RArmlength = 1f;

    //Sprite Renderers for limbs, handling sprite flipping
    private SpriteRenderer ForearmFRONT;
    private SpriteRenderer UpperArmFRONT;

    private SpriteRenderer ForearmBACK;
    private SpriteRenderer UpperArmBACK;

    private SpriteRenderer LegFRONT;
    private SpriteRenderer ThighFRONT;

    private SpriteRenderer LegBACK;
    private SpriteRenderer ThighBACK;

    //Player Animator for handling animations
    private Animator PlayerAnim;

    public float bounceHeight; // Force applied when hitting a spike

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("The tingles! do you feel them? We must have more!");
        print("Indeed. 500 hundered Compiler Errors");

        PlayerAnim = GetComponent<Animator>();

        ForearmFRONT = transform.Find("Doll Forearm FRONT").GetComponent<SpriteRenderer>();
        UpperArmFRONT = transform.Find("Doll Upper Arm FRONT").GetComponent<SpriteRenderer>();
        ForearmBACK = transform.Find("Doll Forearm BACK").GetComponent<SpriteRenderer>();
        UpperArmBACK = transform.Find("Doll Upper Arm BACK").GetComponent<SpriteRenderer>();
        LegFRONT = transform.Find("Doll Leg FRONT").GetComponent<SpriteRenderer>();
        ThighFRONT = transform.Find("Doll Thigh FRONT").GetComponent<SpriteRenderer>();
        LegBACK = transform.Find("Doll Leg BACK").GetComponent<SpriteRenderer>();
        ThighBACK = transform.Find("Doll Thigh BACK").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        #region Player Movement Handling

        //Player Gravity
        PlayerDirection.y = GetComponent<Rigidbody2D>().linearVelocity.y;

        //Yewoch Animation stop
        if (isGrounded() && PlayerAnim.GetBool("isYeowch"))
        {             PlayerAnim.SetBool("isYeowch", false);
        }



        #region Player X-Axis Movement
        if (Input.GetKey(KeyCode.D) && canMove)//+X Move
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            if (isGrounded())
            {
                PlayerDirection.x += Acceleration * Time.deltaTime;
                //Flips the Player's Sprite when moving left
                

                ForearmFRONT.sortingOrder = 12;
                UpperArmFRONT.sortingOrder = 11;

                ForearmBACK.sortingOrder = 1;
                UpperArmBACK.sortingOrder = 2;

                LegFRONT.sortingOrder = 10;
                ThighFRONT.sortingOrder = 9;

                LegBACK.sortingOrder = 4;
                ThighBACK.sortingOrder = 3;

            }
            else
            {
                PlayerDirection.x += AirSpeed * Time.deltaTime;

            }

            

        }

        else if (Input.GetKey(KeyCode.A) && canMove)//-X Move
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            if (isGrounded())
            {
                PlayerDirection.x -= Acceleration * Time.deltaTime;
                //Flips the Player's Sprite when moving left
                
               
                ForearmFRONT.sortingOrder = 1;
                UpperArmFRONT.sortingOrder = 2;

                ForearmBACK.sortingOrder = 12;
                UpperArmBACK.sortingOrder = 11;

                LegFRONT.sortingOrder = 4;
                ThighFRONT.sortingOrder = 3;

                LegBACK.sortingOrder = 10;
                ThighBACK.sortingOrder = 9;

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
                PlayerDirection.x = Mathf.Lerp(PlayerDirection.x, 0, Time.deltaTime * Deceleration);
                if (Mathf.Abs(PlayerDirection.x) <= 0.5f)
                {
                    PlayerDirection.x = 0;
                }

            }
        }

        //Starts the Walking Anim if moving on the X-Axis
        if (PlayerDirection.x != 0)
        {
            PlayerAnim.SetBool("IsWalking", true);
            PlayerAnim.SetBool("isRunning", false);
            isRunning = false;
        }

        //Stops the Walking Anim if not moving on the X-Axis
        if (PlayerDirection.x == 0)
        {
            PlayerAnim.SetBool("IsWalking", false);
            isRunning = false;
        }

        if (PlayerDirection.x >= 7 || PlayerDirection.x <= -7)
        {
            
            PlayerAnim.SetBool("isRunning", true);
            isRunning = true;
        }

        //Clamps the Player's X-Axis Speed to the MaxSpeed Variable
        PlayerDirection.x = Mathf.Clamp(PlayerDirection.x, -MaxSpeed, MaxSpeed);
        PlayerDirection.y = Mathf.Clamp(PlayerDirection.y, -MaxVerticalSpeed, MaxVerticalSpeed);
        #endregion

        #region Player Y-Axis Movement
        //Jump Move        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            PlayerDirection.y += JumpStrength;
             
        }
        

        if (!isGrounded())
        {
            PlayerAnim.SetBool("isJumping", true);
        }
        else if (isGrounded())
        {
            PlayerAnim.SetBool("isJumping", false);
        
        }
        
        

        //Climbing Movement 
        if (Input.GetKey(KeyCode.F))
        {
            if (isClimbingRight())
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    PlayerDirection.y += ClimbSpeed * Time.deltaTime;
                }
                else
                {
                    PlayerDirection.y = 0;
                }

            }
            else if (isClimbingLeft())
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    PlayerDirection.y += ClimbSpeed * Time.deltaTime;
                }
                else
                {
                    PlayerDirection.y = 0;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }

        //Controls Animation bools for Jumping
        if (!isGrounded() && !isClimbingLeft() || !isGrounded() && !isClimbingRight())
        {
            PlayerAnim.SetBool("isJumping", true);
        }
        else if (isGrounded())
        {
            PlayerAnim.SetBool("isJumping", false);

        }

        //Controls Animation bools for Climbing
        if (isClimbingLeft() && PlayerDirection.y > 0 && Input.GetKey(KeyCode.W) || isClimbingRight() && PlayerDirection.y > 0 && Input.GetKey(KeyCode.W))
        {
            PlayerAnim.SetBool("IsClimbing", true);
            PlayerAnim.SetBool("isJumping", false);
            PlayerAnim.SetBool("isYeowch", false);
        }
        else
        {
            PlayerAnim.SetBool("IsClimbing", false);
        }

        //Controls Left Climbing Cooldown
        if (isClimbingLeft())
        {
            LArmlength = 0.8f;
            PlayerDirection.x = 0;
            Debug.Log("Climbing");


            //Allows the player to stop climbing
            if (isClimbingLeft() && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(WaitToClimb());
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                StartCoroutine(WaitToClimb());
            }

        }

        //Controls Right Climbing Cooldown
        if (isClimbingRight())
        {
            PlayerDirection.x = 0;
            RArmlength = 0.8f;


            if (isClimbingRight() && Input.GetKey(KeyCode.A))
            { 
                StartCoroutine(WaitToClimb());
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                StartCoroutine(WaitToClimb());
            }

            
        }
        #endregion //ends y-axis movement handling


        GetComponent<Rigidbody2D>().linearVelocity = PlayerDirection;
        
        #endregion
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
         {
            Debug.Log("Player hit a spike! Bouncing.");
            //PlayerDirection.y += bounceHeight;
            gameObject.GetComponent<Rigidbody2D>().linearVelocityY += bounceHeight;
            PlayerAnim.SetBool("isYeowch", true);
        }
    }

    //Methods for ground/Wall check
    [HideInInspector] public bool isGrounded()
    {
        return Physics2D.Raycast(transform.position + (Vector3)GroundOffset, Vector2.down, HalfBodyDistance, Ground);
    }

     public bool isClimbingLeft()
    {
        return Physics2D.Raycast(transform.position + (Vector3)LOffset, Vector2.left, LArmlength, Climbable);
    }
      public bool isClimbingRight()
    {
        return Physics2D.Raycast(transform.position + (Vector3)ROffset, Vector2.right, RArmlength, Climbable);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + (Vector3)GroundOffset, transform.position + (Vector3)GroundOffset + Vector3.down * HalfBodyDistance);
        Gizmos.DrawLine(transform.position + (Vector3)LOffset, transform.position + (Vector3)LOffset + Vector3.left * LArmlength);
        Gizmos.DrawLine(transform.position + (Vector3)ROffset, transform.position + (Vector3)ROffset + Vector3.right * RArmlength);
    }

    private IEnumerator WaitToClimb()
    {
        LArmlength = 0;
        RArmlength = 0;
        yield return new WaitForSeconds(1f);
        LArmlength = 0.8f;
        RArmlength = 0.8f;
    }

   


}   
