using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthBar : MonoBehaviour
{
    public Slider Slider;

    private Coroutine _coroutine;
    private float _target;
    private float _maxHealth = 100f;

    private void Start()
    {
        Slider.maxValue = _maxHealth;
        Slider.value = 100f;
        _target = Slider.value;
    }

    public void MoveLeft()
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameValue(-10f));
    }

    public void MoveRight()
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameValue(10f));
    }

    private IEnumerator RenameValue(float valume)
    {
        _target += valume;

        while (Slider.value != _target)
        {
            float speed = 10.1f;
            Slider.value = Mathf.MoveTowards(Slider.value, _target, speed * Time.deltaTime);
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
