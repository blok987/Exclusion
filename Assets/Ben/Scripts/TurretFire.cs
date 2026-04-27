using UnityEngine;

public class TurretFire : MonoBehaviour
{
    private Animator turretAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turretAnim = gameObject.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            turretAnim.SetBool("isFiring", true);
            Debug.Log("Player entered turret range");
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            turretAnim.SetBool("isFiring", false);
            Debug.Log("Player left turret range");
        }
    }
}
