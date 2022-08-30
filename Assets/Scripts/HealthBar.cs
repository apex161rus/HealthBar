using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 20f;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valume)
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(ChangeValue(valume));
    }

    private IEnumerator ChangeValue(float valume)
    {
        while (_slider.value != valume)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, valume, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void CheckForStopAttempt(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
