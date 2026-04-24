using UnityEngine;

public class RandomArmDamage : MonoBehaviour
{
    public HealthArm1 playerArm1Health;
    public HealthArm2 playerArm2Health;

    public GameObject playerArm1;
    public GameObject playerArm2;

    public PlayerBodyCollision playerBodyCollision;
    private int rd;

    private bool isArm1Dead = false;
    private bool isArm2Dead = false;

    private void FixedUpdate()
    {
        if (playerArm1.activeSelf == false)
        {
           isArm1Dead = true;
        }

        if (playerArm2.activeSelf == false)
        {
            isArm2Dead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("hurt") || collision.gameObject.transform.CompareTag("Spike"))
        {

            rd = Random.Range(1, 20);

            if (rd <= 10 && isArm1Dead == false)
            {
                playerArm1Health.TakeDamage(2);
                Debug.Log("Arm 1 took damage");
                playerBodyCollision.isArm1Colliding = true;
                Debug.Log("rd is " + rd);
            }
            if (rd <= 10 && isArm1Dead == true)
            {
                playerArm2Health.TakeDamage(2);
                playerBodyCollision.isArm2Colliding = true;
                Debug.Log("rd is " + rd);
            }

            if (rd >= 11 && isArm2Dead == false)
            {
                playerArm2Health.TakeDamage(2);
                Debug.Log("Arm 2 took damage");
                playerBodyCollision.isArm2Colliding = true;
                Debug.Log("rd is " + rd);
            }
            if (rd >= 11 && isArm2Dead == true)
            {
                playerArm1Health.TakeDamage(2);
                playerBodyCollision.isArm1Colliding = true;
                Debug.Log("rd is " + rd);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.CompareTag("hurt") || collision.gameObject.transform.CompareTag("Spike"))
        {

            rd = Random.Range(1, 20);

            if (rd <= 10 && isArm1Dead == false)
            {
                playerArm1Health.TakeDamage(2);
                Debug.Log("Arm 1 took damage");
                playerBodyCollision.isArm1Colliding = true;
                Debug.Log("rd is " + rd);
            }
            if (rd <= 10 && isArm1Dead == true)
            {
                playerArm2Health.TakeDamage(2);
                playerBodyCollision.isArm2Colliding = true;
                Debug.Log("rd is " + rd);
            }

            if (rd >= 11 && isArm2Dead == false)
            {
                playerArm2Health.TakeDamage(2);
                Debug.Log("Arm 2 took damage");
                playerBodyCollision.isArm2Colliding = true;
                Debug.Log("rd is " + rd);
            }
            if (rd >= 11 && isArm2Dead == true)
            {
                playerArm1Health.TakeDamage(2);
                playerBodyCollision.isArm1Colliding = true;
                Debug.Log("rd is " + rd);
            }
        }
    }


}
