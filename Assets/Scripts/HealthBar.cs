using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Slider Slider;
    [SerializeField] private Player _player;

    private Coroutine _coroutine;

    private void Start()
    {
        Slider.maxValue = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnRenameDamage;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnRenameDamage;
    }

    private void OnRenameDamage(float valume)
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameValue(valume));
    }

    private IEnumerator RenameValue(float valume)
    {
        while (Slider.value != valume)
        {
            float speed = 20.0f;
            Slider.value = Mathf.MoveTowards(Slider.value, valume, speed * Time.deltaTime);
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
