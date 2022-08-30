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
        if (_health > _minHealth)
        {
            _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
            HealthChanged?.Invoke(_health);
        }
    }

    public void Heal()
    {
        float treatment = 10f;
        if (_health < _maxHealth)
        {
            _health = Mathf.Clamp(_health + treatment, _minHealth, _maxHealth);
            HealthChanged?.Invoke(_health);
        }
    }
}
