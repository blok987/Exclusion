using UnityEngine;

public class RandomArmDamage : MonoBehaviour
{
    public HealthArm1 playerArm1Health;
    public HealthArm2 playerArm2Health;
    public PlayerBodyCollision playerBodyCollision;
    private int rd;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        rd = Random.Range(1, 100);

        if (rd <= 50)
        {
            playerArm1Health.TakeDamage(2);
            Debug.Log("Arm 1 took damage");
            playerBodyCollision.isArm1Colliding = true;
        }
        else if (rd <= 50 && gameObject.transform.childCount < 2)
        {
            playerArm2Health.TakeDamage(2);
            playerBodyCollision.isArm2Colliding = true;
        }

        if (rd >= 51)
        {
            playerArm2Health.TakeDamage(2);
            Debug.Log("Arm 2 took damage");
            playerBodyCollision.isArm2Colliding = true;
        }
        else if (rd >= 51 && gameObject.transform.childCount < 2)
        {
            playerArm1Health.TakeDamage(2);
            playerBodyCollision.isArm1Colliding = true;
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
