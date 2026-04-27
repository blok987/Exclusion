using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public Transform firePoint;

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
            
           // Debug.Log("Player entered turret range");
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

    private void Shoot()
    {
        // Implement shooting logic here, such as instantiating a bullet prefab and setting its direction towards the player
        Debug.Log("Turret is shooting!");
    }
}
