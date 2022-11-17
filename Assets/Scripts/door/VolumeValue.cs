using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private float speed;

    private float _minimalVolume = 1f;
    private float _maximumVolume = 10f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeIn()); ;
    }

    private IEnumerator FadeIn()
    {
        var volume = _audioSource.volume;
        var waitForOneSeconds = new WaitForSeconds(1f);

        for (int i = 0; i < _maximumVolume; i++)
        {
            volume = _minimalVolume - (_minimalVolume / _maximumVolume * i);
            _audioSource.volume = Mathf.MoveTowards(volume, i, speed);
            yield return waitForOneSeconds;
        }
    }
}
