using UnityEngine;

public class Hazard : MonoBehaviour
{

    public float damage = 2;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out Stats stats))
        {
            float calculatedDamage = damage -= stats.defense;
            stats.currentHealth -= calculatedDamage;
            
        }
    }
}
