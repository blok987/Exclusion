using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 2;
    public Health playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           playerHealth.TakeDamage(damage);
        }
    }
}
