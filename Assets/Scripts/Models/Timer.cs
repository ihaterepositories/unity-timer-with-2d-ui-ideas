using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration;

    private float timeRemaining;
    private bool isTimeOver;

    public float Duration { get { return duration; } }
    public float TimeRemaining { get { return timeRemaining; } }
    public bool IsTimeOver { get { return isTimeOver; } }

    public static event Action OnTimeOver;

    private void Awake()
    {
        if (duration is 0f) { duration = 300f; }
    }

    private void OnEnable()
    {
        StartGameManager.OnStartGame += StartTimer;
    }

    private void OnDisable()
    {
        StartGameManager.OnStartGame -= StartTimer;
    }

    public void StartTimer()
    {
        isTimeOver = false;
        timeRemaining = duration;
        StartCoroutine(StartTimerCoroutine());
    }

    public void StopTimer()
    {
        StopCoroutine(StartTimerCoroutine());
    }

    public void ContinueTimer()
    {
        StartCoroutine(StartTimerCoroutine());
    }

    private IEnumerator StartTimerCoroutine()
    {
        while (timeRemaining >= 1f)
        {
            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        TimeOver();
    }

    private void TimeOver()
    {
        isTimeOver = true;
        OnTimeOver?.Invoke();
    }

    public bool IsMoreThanSomeTimeLeft(float time)
    {
        return timeRemaining > time;
    }

    public bool IsLessThanSomeTimeLeft(float time)
    {
        return timeRemaining < time;
    }
}