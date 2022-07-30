using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 20f;

    private Coroutine _coroutine;

    private void Start()
    {
        Slider.maxValue = _player.MaxHealth;
        Slider.value = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.ChangeHealth += OnZoroviaChanged;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= OnZoroviaChanged;
    }

    private void OnZoroviaChanged(float valume)
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameValue(valume));
    }

    private IEnumerator RenameValue(float valume)
    {
        while (Slider.value != valume)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, valume, _speed * Time.deltaTime);
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
