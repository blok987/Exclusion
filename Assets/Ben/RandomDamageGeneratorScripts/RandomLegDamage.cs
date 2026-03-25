using UnityEngine;

public class RandomLegDamage : MonoBehaviour
{
    public HealthLeg1 playerLeg1Health;
    public HealthLeg2 playerLeg2Health;
    public PlayerBodyCollision playerBodyCollision;
    private int rd;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        rd = Random.Range(1, 100);

        if (rd <= 50)
        {
            playerLeg1Health.TakeDamage(2);
            Debug.Log("Arm 1 took damage");
            playerBodyCollision.isLeg1Colliding = true;
        }
        else if (rd <= 50 && gameObject.transform.childCount < 2)
        {
            playerLeg2Health.TakeDamage(2);
            playerBodyCollision.isLeg2Colliding = true;
        }

        if (rd >= 51)
        {
            playerLeg2Health.TakeDamage(2);
            Debug.Log("Arm 2 took damage");
            playerBodyCollision.isLeg2Colliding = true;
        }
        else if (rd >= 51 && gameObject.transform.childCount < 2)
        {
            playerLeg1Health.TakeDamage(2);
            playerBodyCollision.isLeg1Colliding = true;
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

