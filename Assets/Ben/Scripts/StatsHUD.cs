using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public Stats stats;

    public Image healthbar;
    
    

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = stats.currentHealth / stats.maxHealth;
        
    }
}
