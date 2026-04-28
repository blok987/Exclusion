using UnityEngine;

public class TurretFire : MonoBehaviour
{
    private Animator turretAnim;

    public GameObject bulletPrefab;

    public Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turretAnim = gameObject.GetComponent<Animator>();
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}