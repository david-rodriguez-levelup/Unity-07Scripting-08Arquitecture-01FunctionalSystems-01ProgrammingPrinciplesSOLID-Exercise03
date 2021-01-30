using System;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{

    public event Action<float> OnChange;

    [SerializeField] float maxHealth;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(float amount)
    {
        float previousHealth = currentHealth;
        
        currentHealth += amount;
        
        if (currentHealth != previousHealth)
        {
            OnChange?.Invoke(currentHealth);
        }
    }

}
