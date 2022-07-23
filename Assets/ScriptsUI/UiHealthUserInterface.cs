using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]

public class UiHealthUserInterface : MonoBehaviour
{
    public Slider Slider;

    private Player _player;
    private Coroutine _coroutine;
    private float _target;
    private float _maxHealth = 100f;

    public void InflictDamage()
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameValue(-10f));
    }

    public void Treat()
    {
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameValue(10f));
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        Slider.maxValue = _maxHealth;
        Slider.value = _player.Health;
        _target = Slider.value;
    }

    private IEnumerator RenameValue(float valume)
    {
        _target += valume;

        while (Slider.value != _target)
        {
            float speed = 10.1f;
            Slider.value = Mathf.MoveTowards(Slider.value, _target, speed * Time.deltaTime);
            _player.RenameHealth(Slider.value);
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
