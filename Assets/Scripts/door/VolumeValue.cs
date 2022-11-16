using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeValue : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private float speed;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeIn()); ;
    }

    private IEnumerator FadeIn()
    {
        var volume = _audioSource.volume;
        var waitForOneSeconds = new WaitForSeconds(1f);

        for (int i = 0; i < 10; i++)
        {
            volume = 1f - (1f / 10f * i);
            _audioSource.volume = Mathf.MoveTowards(volume, i, speed);
            yield return waitForOneSeconds;
        }
    }

}
