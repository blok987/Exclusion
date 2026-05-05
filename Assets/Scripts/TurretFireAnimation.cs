using UnityEngine;

public class TurretFireAnimation : MonoBehaviour
{

    private Animator turretAnim;

    private TurretFire turretFireScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turretAnim = gameObject.GetComponentInParent<Animator>();
        turretFireScript = gameObject.GetComponentInParent<TurretFire>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (turretFireScript.canShoot)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                turretAnim.SetBool("isFiring", true);

                // Debug.Log("Player entered turret range");
            }
        }
        else if (!turretFireScript.canShoot)
        {
            turretAnim.SetBool("isFiring", false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            turretAnim.SetBool("isFiring", false);
            //Debug.Log("Player left turret range");
        }
    }

    
}
