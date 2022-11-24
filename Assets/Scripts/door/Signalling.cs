using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalling : MonoBehaviour
{
    [SerializeField] private float _speedChangeVolume;

    private AudioSource _audioSource;
    private float _minimalVolume = 0;
    private float _maximalVolume = 1;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Change(bool isUpVolume = true)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        if (isUpVolume)
        {
            _audioSource.Play();
            _coroutine = StartCoroutine(MoveValue(_maximalVolume));
        }
        else
        {
            _coroutine = StartCoroutine(MoveValue(_minimalVolume));
        }
    }

    private IEnumerator MoveValue(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speedChangeVolume * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == _minimalVolume)
            _audioSource.Stop();
    }
}
