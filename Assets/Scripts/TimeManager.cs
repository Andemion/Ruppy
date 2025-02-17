using UnityEngine;
using System;
public class TimeManager : MonoBehaviour
{
    public float Duration = 120f;
    public float Remaining {get; private set;}
    public bool Running {get; private set;}
    public event Action OnTimeUp;

    public void Start()
    {
        Reset();
        StartTimer();
    }
    public void Reset()
    {
        Remaining = Duration;
    }

    public void Update()
    {
        if(Running)
        {
            Tick(Time.deltaTime);
        }
    }

    private void Tick(float deltaTime)
    {
        Remaining -= deltaTime;

        if (Remaining <= 0f)
        {
            Remaining = 0f;
            OnTimeUp?.Invoke();
        }
    }

    public void StartTimer()
    {
        Running = true;
    }

    public void StopTimer()
    {
        Running = false;
    }
}
