using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _health = 100f;
    private float _maxHealth = 100;
    private float _minHealth = 0f;
    public float MaxHealth => _maxHealth;

    public event UnityAction<float> OnHealthChanged;

    private void Start()
    {
        OnHealthChanged?.Invoke(_health);
    }

    public void MakeDamageButton()
    {
        float damage = 10f;

        if (_health > _minHealth)
        {
            _health -= damage;
            OnHealthChanged?.Invoke(_health);
        }
    }

    public void AddHealButton()
    {
        float treatment = 10f;

        if (_health < _maxHealth)
        {
            _health += treatment;
            OnHealthChanged?.Invoke(_health);
        }
    }
}
