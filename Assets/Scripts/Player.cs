using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _health = 100f;
    private float _maxHealth = 100;
    private float _minHealth = 0f;

    public float MaxHealth => _maxHealth;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage()
    {
        float damage = 10f;
        _health -= damage;
        HealthChanged?.Invoke(_health);
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }

    public void Heal()
    {
        float treatment = 10f;
        _health += treatment;
        HealthChanged?.Invoke(_health);
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }
}
