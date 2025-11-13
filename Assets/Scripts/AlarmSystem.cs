using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private float _volumeStep = 0.1f;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _maxVolume = 1.0f;
    
    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _alarmAudioSource.volume = _minVolume;
        _alarmAudioSource.loop = true;
    }

    private void ChangeVolume(float volumeTarget)
    {
        if(_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }

        _volumeCoroutine = StartCoroutine(VolumeCoroutine(volumeTarget));
    }

    private IEnumerator VolumeCoroutine(float volumeTarget)
    {
        if(volumeTarget > _minVolume && _alarmAudioSource.isPlaying == false)
        {
            _alarmAudioSource.Play();
        }

        while(Mathf.Approximately(_alarmAudioSource.volume, volumeTarget) == false)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, volumeTarget, _volumeStep * Time.deltaTime);

            yield return null;
        }

        if(Mathf.Approximately(volumeTarget, _minVolume))
        {
            _alarmAudioSource.Stop();
        }
    }

    public void TurnOn()
    {
        ChangeVolume(_maxVolume);
    }

    public void TurnOff()
    {
        ChangeVolume(_minVolume);
    }
}
