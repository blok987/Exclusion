using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

   [SerializeField] HealthBar _healthbar;
    [SerializeField] Stats stats;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTakeDamage();
    }

    private void PlayerTakeDamage()
    {
        _healthbar.setHealth((int)stats.currentHealth);
    }
}
