using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private float _volumeStep = 0.1f;
    [SerializeField] private float _minVolume = 0f;

    private float _maxVolume = 1.0f;
    private int _thiefsCount = 0;
    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _alarmAudioSource.volume = _minVolume;
        _alarmAudioSource.loop = true;
        _alarmAudioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        int minThiefsForTriggerAlarm = 1;

        if(other.GetComponent<Thief>() != null)
        {
            _thiefsCount++;

            if(_thiefsCount >= minThiefsForTriggerAlarm)
            {
                ChangeVolume(_maxVolume);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Thief>() != null)
        {
            _thiefsCount--;

            if(_thiefsCount == 0)
            {
                ChangeVolume(_minVolume);
            }
        }
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
        while(Mathf.Approximately(_alarmAudioSource.volume, volumeTarget) == false)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, volumeTarget, _volumeStep * Time.deltaTime);

            yield return null;
        }

        _volumeCoroutine = null;
    }
}
