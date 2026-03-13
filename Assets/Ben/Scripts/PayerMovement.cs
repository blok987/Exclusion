using UnityEngine;
using UnityEngine.InputSystem;

public class PayerMovement : MonoBehaviour
{


    
    private GameObject player;
    public float moveSpeed;
    public float jumpHeight = 4f;
    public float speed = 3.0f;


   
    private Rigidbody2D rb2d;
    private float _movement;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.linearVelocityX = _movement;
        moveSpeed = rb2d.linearVelocity.x;
    }

    
    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * speed;
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            
            rb2d.linearVelocityY = jumpHeight;
            
                
            
            

        }
    }
  
    
   
    
   
   
}