using UnityEngine;

public class TurretFire : MonoBehaviour
{
    private Animator turretAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turretAnim = gameObject.GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            turretAnim.SetBool("isFiring", true);
            Debug.Log("Player entered turret range");
        }
        else
        {
            turretAnim.SetBool("isFiring", false);
        }
    }
}
