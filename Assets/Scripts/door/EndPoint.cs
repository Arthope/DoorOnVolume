
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private float _speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _reached.Invoke();
            var fadeInJob = StartCoroutine(FadeIn());
        }
    }
    private IEnumerator FadeIn()
    {
        var volume = _audioSource.volume;
        var waitForOneSeconds = new WaitForSeconds(1f);

        for (int i = 0; i < 10; i++)
        {
            volume = 1f - (1f / 10f * i);
            _audioSource.volume = Mathf.MoveTowards(volume, i, _speed);
            yield return waitForOneSeconds;
        }
    }
}

