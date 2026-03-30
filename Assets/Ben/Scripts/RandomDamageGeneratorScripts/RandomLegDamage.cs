using UnityEngine;

public class RandomLegDamage : MonoBehaviour
{
    public HealthLeg1 playerLeg1Health;
    public HealthLeg2 playerLeg2Health;

    public GameObject playerLeg1;
    public GameObject playerLeg2;

    private BoxCollider2D RandomLegCollider;

    private bool isLeg1Dead = false;
    private bool isLeg2Dead = false;

    public PlayerBodyCollision playerBodyCollision;
    private int rd;


    private void Start()
    {
       RandomLegCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if (playerLeg1 == null)
        {
            isLeg1Dead = true;
        }

        if (playerLeg2 == null)
        {
            isLeg2Dead = true;
        }

        if (playerLeg1 == null && playerLeg2 == null)
        {
            RandomLegCollider.enabled = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.transform.CompareTag("hurt") )
        {
            rd = Random.Range(1, 50);

            if (rd <= 25 && isLeg1Dead == false)
            {
                playerLeg1Health.TakeDamage(2);
                Debug.Log("Leg 1 took damage");
                Debug.Log("rd is " + rd);
                playerBodyCollision.isLeg1Colliding = true;
            }
            if (rd <= 25 && isLeg1Dead == true)
            {
                playerLeg2Health.TakeDamage(2);
                playerBodyCollision.isLeg2Colliding = true;
                Debug.Log("rd is " + rd);
            }

            if (rd >= 26 && isLeg2Dead == false)
            {
                playerLeg2Health.TakeDamage(2);
                Debug.Log("Leg 2 took damage");
                playerBodyCollision.isLeg2Colliding = true;
                Debug.Log("rd is " + rd);
            }
            if (rd >= 26 && isLeg2Dead == true)
            {
                playerLeg1Health.TakeDamage(2);
                playerBodyCollision.isLeg1Colliding = true;
                Debug.Log("rd is " + rd);
            }
        }
    }

    
}

