using System.Collections;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public BullletScript bulletScript;

    public bool canShoot = true;

    private float shootCounter;

    private AudioSource audioSource;    

    public AudioClip shootSound;


    void Start()
    {
        shootCounter = 0;
        shootSound = Resources.Load<AudioClip>("Audio/SFX/gunshot");
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

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

        //Checks to see how many bullets have been shot and if it is greater than 6, the turret goes on cooldown
        if (shootCounter >= 6)
        {
            StartCoroutine(Cooldown());
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            audioSource.PlayOneShot(shootSound);
            shootCounter += 1;
        }
    }

    private IEnumerator Cooldown()
    {
        canShoot = false;
        shootCounter = 0;
        yield return new WaitForSeconds(5);
        canShoot = true;
    }
}