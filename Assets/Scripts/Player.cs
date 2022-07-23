using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100f;

    public float Health => _health;

    public void RenameHealth(float value)
    {
        _health = value;
    }
}
