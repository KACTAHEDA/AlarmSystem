using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action TheifEntered;
    public event Action TheifExited;

    public int CurentThiefsCount { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Thief>() != null)
        {
            CurentThiefsCount++;

            TheifEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Thief>() != null)
        {
            CurentThiefsCount--;

            TheifExited?.Invoke();
        }
    }
}
