using UnityEngine;

public class DamageInflictor : MonoBehaviour
{

    [SerializeField] private float damage;

    public void InflictDamage(HealthBehaviour healthBehaviour)
    {
        healthBehaviour.ChangeHealth(-damage);
    }

}
