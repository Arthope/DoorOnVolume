using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private _maximumValue;
    [SerializeField] private _minimumValue;

    private Coroutine _activeCoroutine;
    private float _recoveryRate = 0.5f;
    private float _requiredValue;

    public void PlaySound()
    {
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _maximumValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minimumValue, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
