using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [Header("Bars")]
    [Tooltip("This entity's max health")] [Range(1, 100)] public float maxHealth;
     public float currentHealth;

    [Tooltip("This entity's max mana")][Range(0, 50)] public float maxMana;
    [HideInInspector] public float currentMana;

    [Header("Attack")]

    [Tooltip("This entity's damage")] public float damage;
    [Tooltip("This entity's defense. Defense is subtracted from damage")] public float defense;

    [Tooltip("This entity's currency")] public int currency;

    [Tooltip("whether or not this entity is dead")] public bool isDead = false;

    [Tooltip("how much healing this entity does on pickkup")] public float healing;

    public UnityEvent OnDied;

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

    }
    private void Update()
    {

      //  if (Input.GetButtonDown("Escape"))
      //  {
      //      SceneManager.LoadScene("Start");
      //  }

        if (currentHealth <= 0)
        {
            
            isDead = true;
            Destroy(gameObject);
            

            
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }
}
