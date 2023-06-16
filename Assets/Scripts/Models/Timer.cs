using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration;

    private Coroutine timerCoroutine;
    private float timeRemaining;
    private bool isTimeOver;

    public float Duration { get { return duration; } }
    public float TimeRemaining { get { return timeRemaining; } }
    public bool IsTimeOver { get { return isTimeOver; } }

    public static event Action OnTimerStart;
    public static event Action<float, float> OnTimerWorking;
    public static event Action OnTimerFinish;

    private void Awake()
    {
        if (duration is 0f) { duration = 300f; }
    }

    private void OnEnable()
    {
        StartTimerButton.OnStartTimerButtonClicked += StartTimer;
        ContinueTimerButton.OnContinueTimerButtonClicked += ContinueTimer;
        StopTimerButton.OnStopTimerButtonClicked += StopTimer;
    }

    private void OnDisable()
    {
        StartTimerButton.OnStartTimerButtonClicked -= StartTimer;
        ContinueTimerButton.OnContinueTimerButtonClicked -= ContinueTimer;
        StopTimerButton.OnStopTimerButtonClicked -= StopTimer;
    }

    public void StartTimer()
    {
        isTimeOver = false;
        timeRemaining = duration;
        OnTimerStart?.Invoke();
        timerCoroutine = StartCoroutine(StartTimerCoroutine());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    public void ContinueTimer()
    {
        timerCoroutine = StartCoroutine(StartTimerCoroutine());
    }

    private IEnumerator StartTimerCoroutine()
    {
        while (timeRemaining >= 0f)
        {
            OnTimerWorking?.Invoke(timeRemaining, duration);
            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        TimeOver();
    }

    private void TimeOver()
    {
        isTimeOver = true;
        OnTimerFinish?.Invoke();
    }

    public bool IsMoreThanSomeTimeLeft(float seconds)
    {
        return timeRemaining > seconds;
    }

    public bool IsLessThanSomeTimeLeft(float seconds)
    {
        return timeRemaining < seconds;
    }
}