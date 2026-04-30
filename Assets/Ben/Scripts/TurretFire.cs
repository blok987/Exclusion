using UnityEngine;

public class TurretFire : MonoBehaviour
{


    public GameObject bulletPrefab;

    public Transform firePoint;

    public BullletScript bulletScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        //Changes the direction of the bullet based on the scale of the turret
        if (gameObject.transform.localScale.x < 0)
        {
            bulletScript.directionOfBullet = transform.right;
        }
        else if (gameObject.transform.localScale.x > 0)
        {
            bulletScript.directionOfBullet = -transform.right;
             
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}