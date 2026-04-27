using System.Collections;
using UnityEngine;

public class PlayerBodyCollision : MonoBehaviour
{
    
    public float damage = 2;
    public Health playerHealth;
    
    
    public bool isLeg1Colliding;
    public bool isLeg2Colliding;

    public bool isArm1Colliding;
    public bool isArm2Colliding;

    private bool canBeHurtCol;
    private bool canBeHurtTri;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (canBeHurtCol == true)
        { 

            if (collision.gameObject.CompareTag("hurt") && isLeg1Colliding == false && isLeg2Colliding == false && isArm1Colliding == false && isArm2Colliding == false || collision.gameObject.CompareTag("Spike") && isLeg1Colliding == false && isLeg2Colliding == false && isArm1Colliding == false && isArm2Colliding == false)
            {
                Debug.Log("Player Body Hit");

                playerHealth.TakeDamage(damage);
                StartCoroutine(WaitToTakeDamageCol());
            }

            else if (isLeg1Colliding == true)
            {
                isLeg1Colliding = false;
            }

            else if (isLeg2Colliding == true)
            {
                isLeg2Colliding = false;
            }

            else if (isArm1Colliding == true)
            {
                isArm1Colliding = false;
            }

            else if (isArm2Colliding == true)
            {
                isArm2Colliding = false;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (canBeHurtTri == true)
        {

            if (collision.gameObject.CompareTag("hurt") && isLeg1Colliding == false && isLeg2Colliding == false && isArm1Colliding == false && isArm2Colliding == false || collision.gameObject.CompareTag("Spike") && isLeg1Colliding == false && isLeg2Colliding == false && isArm1Colliding == false && isArm2Colliding == false)
            {
                Debug.Log("Player Body Hit");

                playerHealth.TakeDamage(damage);
                StartCoroutine(WaitToTakeDamageTri());
            }

            else if (isLeg1Colliding == true)
            {
                isLeg1Colliding = false;
            }

            else if (isLeg2Colliding == true)
            {
                isLeg2Colliding = false;
            }

            else if (isArm1Colliding == true)
            {
                isArm1Colliding = false;
            }

            else if (isArm2Colliding == true)
            {
                isArm2Colliding = false;
            }
        }
    }

    private IEnumerator WaitToTakeDamageCol()
    {
        canBeHurtCol = false;
        yield return new WaitForSeconds(0.75f);
        canBeHurtCol = true;
    }

    private IEnumerator WaitToTakeDamageTri()
    {
        canBeHurtTri = false;
        yield return new WaitForSeconds(0.75f);
        canBeHurtTri = true;
    }

}
