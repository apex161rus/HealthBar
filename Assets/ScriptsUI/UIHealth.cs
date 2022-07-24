using UnityEngine;

[RequireComponent(typeof(UiHealthBar))]
[RequireComponent(typeof(Player))]

public class UIHealth : MonoBehaviour
{
    private Player _player;
    private UiHealthBar _uiHealthBar;
    private float _health = 100f;

    private void Start()
    {
        _player = GetComponent<Player>();
        _uiHealthBar = GetComponent<UiHealthBar>();
        _player.RenameHealth(_health);
    }

    public void AddHealButton()
    {
        float treatment = 10f;

        if (_health < 100f)
        {
            _health += treatment;
            _uiHealthBar.MoveRight();
        }
    }

    public void MakeDamageButton()
    {
        float damage = 10f;

        if (_health > 0)
        {
            _health -= damage;
            _uiHealthBar.MoveLeft();
        }
    }
}