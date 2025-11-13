using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField] private int _theifsForAlarming = 1;

    private void OnEnable()
    {
        _alarmTrigger.TheifEntered += OnAlarm;
        _alarmTrigger.TheifExited += OffAlarm; ;
    }

    private void OnDisable()
    {
        _alarmTrigger.TheifEntered -= OnAlarm;
        _alarmTrigger.TheifExited -= OffAlarm;
    }

    private void OnAlarm()
    {
        if (_alarmTrigger.CurentThiefsCount == _theifsForAlarming)
        {
            _alarmSystem.TurnOn();
        }
    }

    private void OffAlarm()
    {
        if(_alarmTrigger.CurentThiefsCount == 0)
        {
            _alarmSystem.TurnOff();
        }
    }
}
