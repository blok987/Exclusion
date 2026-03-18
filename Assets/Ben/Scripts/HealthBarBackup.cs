using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Smoothly animates the UI health bar fill to reflect the player's health.
/// 
/// Plan (pseudocode / detailed steps):
/// 1. On Start:
///    - Read maxHealth and current Health from the referenced `playerHealth`.
///    - Compute initial fill (Health / maxHealth) and set both current and target fill to that value.
/// 2. Keep two internal values:
///    - _currentFillAmount: the value currently shown on the Image.fillAmount.
///    - _targetFillAmount: the desired value based on `Health`.
/// 3. When `UpdateHealth(float amount)` is called:
///    - Subtract `amount` from `Health` and clamp between 0 and maxHealth.
///    - Recompute and store `_targetFillAmount = Health / maxHealth`.
///    - If `_fillSpeed <= 0`, snap immediately to target.
/// 4. In `Update()` (runs every frame):
///    - Smoothly move `_currentFillAmount` toward `_targetFillAmount` using `Mathf.MoveTowards` with speed `_fillSpeed * Time.deltaTime`.
///    - Apply `_currentFillAmount` to `healthBarFill.fillAmount`.
/// 5. Guards:
///    - Avoid division by zero when `maxHealth` is zero or invalid.
///    - Ensure values stay in [0,1].
/// </summary>
public class HealthBarBackup : MonoBehaviour
{
    public Health playerHealth;

    [SerializeField] private Image healthBarFill;
    public float maxHealth;
    public float Health;

    // Positive value controls how quickly the bar moves (units-per-second on normalized 0..1 scale).
    [SerializeField] private float _fillSpeed = 5f;

    // Internal smoothing state
    private float _targetFillAmount;
    private float _currentFillAmount;

    void Start()
    {
        if (playerHealth != null)
        {
            maxHealth = playerHealth.maxHealth;
            Health = playerHealth.health;
        }

        // Guard against invalid maxHealth
        if (maxHealth <= 0f)
        {
            maxHealth = 1f;
        }

        _currentFillAmount = Mathf.Clamp01(Health / maxHealth);
        _targetFillAmount = _currentFillAmount;

        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = _currentFillAmount;
        }
    }

    void Update()
    {
        // Smoothly move current fill toward target each frame
        if (healthBarFill == null)
        {
            return;
        }

        if (!Mathf.Approximately(_currentFillAmount, _targetFillAmount))
        {
            if (_fillSpeed <= 0f)
            {
                // Instant snap if speed not set
                _currentFillAmount = _targetFillAmount;
            }
            else
            {
                _currentFillAmount = Mathf.MoveTowards(
                    _currentFillAmount,
                    _targetFillAmount,
                    _fillSpeed * Time.deltaTime
                );
            }

            healthBarFill.fillAmount = _currentFillAmount;
        }
    }

    // Call to change health (e.g. take damage)
    public void UpdateHealth(float amount)
    {
        // Subtract amount and clamp to valid range
        Health = Mathf.Clamp(Health - amount, 0f, maxHealth);

        UpdateHealthBar();
    }

    // Computes and sets the target fill amount. The actual visible fill updates smoothly in Update().
    private void UpdateHealthBar()
    {
        if (maxHealth <= 0f)
        {
            _targetFillAmount = 0f;
            return;
        }

        float targetFillAmount = Health / maxHealth;
        _targetFillAmount = Mathf.Clamp01(targetFillAmount);

        // If speed is zero or negative, immediately apply the target to the UI
        if (_fillSpeed <= 0f && healthBarFill != null)
        {
            _currentFillAmount = _targetFillAmount;
            healthBarFill.fillAmount = _currentFillAmount;
        }
    }
}
