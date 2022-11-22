using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signalling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void TurnOn()
    {
        int targetVolume = 1;

        StartCoroutine(ChangeVolumeSmoothly(targetVolume));
    }

    public void TurnOff()
    {
        int targetVolume = 0;

        StartCoroutine(ChangeVolumeSmoothly(targetVolume));
    }

    private IEnumerator ChangeVolumeSmoothly(int targetVolume)
    {

        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        while (_audioSource.volume < targetVolume || _audioSource.volume > targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume <= 0 && _audioSource.isPlaying == true)
        {
            _audioSource.Stop();
        }
    }
}
