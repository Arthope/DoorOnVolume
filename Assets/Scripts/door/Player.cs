using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;

    public event UnityAction<int> HealthChenged;

    public void Start()
    {
        HealthChenged?.Invoke(_health);
    }
}
