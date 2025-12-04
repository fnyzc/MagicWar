using UnityEngine;

public class Health_sc : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public System.Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"{gameObject.name} took {amount} damage. HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"{gameObject.name} healed {amount}. HP: {currentHealth}");
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died!");

        OnDeath?.Invoke();

        Destroy(gameObject);
    }
}
