using UnityEngine;

public class RandomLegDamage : MonoBehaviour
{
    public HealthLeg1 playerLeg1Health;
    public HealthLeg2 playerLeg2Health;
    public PlayerBodyCollision playerBodyCollision;
    private int rd;



    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("hurt"))
        {
            rd = Random.Range(1, 50);

            if (rd <= 25)
            {
                playerLeg1Health.TakeDamage(2);
                Debug.Log("Leg 1 took damage");
                playerBodyCollision.isLeg1Colliding = true;
            }
            else if (rd <= 25 && gameObject.transform.childCount < 2)
            {
                playerLeg2Health.TakeDamage(2);
                playerBodyCollision.isLeg2Colliding = true;
            }

            if (rd >= 26)
            {
                playerLeg2Health.TakeDamage(2);
                Debug.Log("Leg 2 took damage");
                playerBodyCollision.isLeg2Colliding = true;
            }
            else if (rd >= 26 && gameObject.transform.childCount < 2)
            {
                playerLeg1Health.TakeDamage(2);
                playerBodyCollision.isLeg1Colliding = true;
            }
        }
    }

    void Update()
    {
        if (gameObject.transform.childCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}

