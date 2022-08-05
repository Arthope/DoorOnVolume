using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChenged;
    public int Health => _health;

    public void Start()
    {
        HealthChenged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChenged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
