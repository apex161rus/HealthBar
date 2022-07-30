using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _health = 100f;
    private float _maxHealth = 100;
    private float _minHealth = 0f;

    public float MaxHealth => _maxHealth;

    public event UnityAction<float> ChangeHealth;

    private void Start()
    {
        ChangeHealth?.Invoke(_health);
    }

    public void TakeDamage()
    {
        MakeDamage();
        ChangeHealth?.Invoke(_health);
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }

    public void Heal()
    {
        ApplyTreatment();
        ChangeHealth?.Invoke(_health);
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }

    private float MakeDamage()
    {
        float damage = 10f;
        _health -= damage;
        return _health;
    }

    private float ApplyTreatment()
    {
        float treatment = 10f;
        _health += treatment;
        return _health;
    }
}
