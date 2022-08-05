using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EndPoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private UnityEvent _reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _reached?.Invoke();
        }
    }
}
