using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _health = 100f;
    private float _maxHealth = 100;
    private float _minHealth = 0f;
    private float _damage = 15f;
    private float _treatment = 10f;

    public float MaxHealth => _maxHealth;

    public event UnityAction<float> ChangeHealth;

    public void TakeDamage()
    {
        if ((_health - _damage) < _minHealth)
        {
            _health = _minHealth;
            ChangeHealth?.Invoke(_health);
        }
        else
        {
            MakeDamage();
            ChangeHealth?.Invoke(_health);
        }
        Debug.Log(_health);
    }

    public void GetTreatment()
    {

        if ((_health + _treatment) > _maxHealth)
        {
            _health = _maxHealth;
            ChangeHealth?.Invoke(_health);
        }
        else
        {
            ApplyTreatment();
            ChangeHealth?.Invoke(_health);
        }
        Debug.Log(_health);
    }

    private void Start()
    {
        ChangeHealth?.Invoke(_health);
    }

    private float MakeDamage()
    {
        _health -= _damage;
        return _health;
    }

    private float ApplyTreatment()
    {
        _health += _treatment;
        return _health;
    }
}
