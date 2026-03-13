using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;

public class PayerMovement : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    [SerializeField] private TrailRenderer tr;

    public Transform groundCheck;
    public GroundHeck groundHeck;
    private GameObject player;
    public float moveSpeed;
    public float jumpHeight = 200.0f;
    public float speed = 3.0f;
    public float dashSpeed = 140f;
    private float dashTime = 1.0f;
    private float dashCooldown = 1f;
    private bool canDash = true;
    private bool isDashing = false;
   
    public bool isgrounded;
    private bool canDoubleJump;
    private Rigidbody2D rb2d;
    private float _movement;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        TrailRenderer tr = GetComponent<TrailRenderer>();

        tr.emitting = false;
    }

    void Update()
    {
          if (groundHeck != null && groundHeck.isground == true) { isgrounded = true; }

        rb2d.linearVelocityX = _movement;
        moveSpeed = rb2d.linearVelocity.x;

        if (!isDashing)
        {
            rb2d.linearVelocity = new Vector2(_movement, rb2d.linearVelocity.y);
        }
        

       // if (rb2d.linearVelocity.x > 0)
       // {
       //     animator.SetInteger("walkdirction", +1);
        //    GetComponent<SpriteRenderer>().flipX = false;
       // }
       // else if (rb2d.linearVelocity.x < 0)
       // {
       //     animator.SetInteger("walkdirction", -1);
       //     GetComponent<SpriteRenderer>().flipX = true;
      //  }
      //  else
      //  {
        //    animator.SetInteger("walkdirction", 0);
      //  }

       // animator.SetBool("isJumping", rb2d.linearVelocity.y != 0);
    }

    
    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * speed;
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (isgrounded == true)
            {
                rb2d.linearVelocityY = jumpHeight;
                isgrounded = false;
                canDoubleJump = true;
            }
            else if (canDoubleJump == true)
            {
                rb2d.linearVelocityY = jumpHeight;
                
                canDoubleJump = false;
            }

        }
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        
        canDash = false;
        isDashing = true;
        float originalGravity = rb2d.gravityScale;
        rb2d.gravityScale = 0;
        Debug.Log("Dash");
        float dr = moveSpeed * dashSpeed;
        rb2d.linearVelocity = new Vector2(dr, 0);
        Debug.Log(rb2d.linearVelocity);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        Debug.Log("End Dash");
        rb2d.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        tr.emitting = false;

    }
    
   
   
}