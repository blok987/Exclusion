using NUnit.Framework.Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PayerMovement : MonoBehaviour
{

    private PlayerInput playerInput;

    private GameObject player;
    public float moveSpeed;
    public float jumpHeight = 4f;
    public float speed = 3.0f;
    

    private bool isRunning;
   
    private Rigidbody2D rb2d;
    private float _movement;

    public Image StaminaBar;

    public float Stamina, MaxStamina;

    public float RunCost;
    public float regenRate;

    private Coroutine staminaRegen;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var sprintMove = playerInput.actions["Sprint"];
        rb2d.linearVelocityX = _movement;
        moveSpeed = rb2d.linearVelocity.x;
        Vector2 direction = new Vector2(_movement, rb2d.linearVelocity.y);
        direction.Normalize();

        if(sprintMove.IsPressed() && Stamina != 0)
        {
            isRunning = true;
        }
        else if (!sprintMove.IsPressed() || Stamina <= 0)
        {
            isRunning = false;
        }
        

        if (isRunning && (direction.x != 0 ))
        {
            rb2d.linearVelocityX = speed * direction.x * 1.5f;
            Stamina -= RunCost * Time.deltaTime;
            if(Stamina < 0)
            {
                Stamina = 0;
            }
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (staminaRegen != null)
            {
                StopCoroutine(staminaRegen);
            }
            staminaRegen = StartCoroutine(StaminaRegen());
        }
        else
        {
            rb2d.linearVelocityX = speed * direction.x;
        }

        


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
   
    private IEnumerator StaminaRegen()
    {
        yield return new WaitForSeconds(1f);

        while(Stamina < MaxStamina)
        {
            Stamina += regenRate / 100f;
            if(Stamina > MaxStamina)
            {
                Stamina = MaxStamina;
            }
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(0.1f);
        }
    }




}