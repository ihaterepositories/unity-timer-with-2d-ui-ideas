using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerText : MonoBehaviour
{
    [SerializeField] private Timer timer;
    private Text timerText;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        TimeToText();
    }

    private void OnEnable()
    {
        Timer.OnTimeOver += ShowGameOverText;
    }

    private void OnDisable()
    {
        Timer.OnTimeOver -= ShowGameOverText;
    }

    private void TimeToText()
    {
        if (!timer.IsTimeOver)
        timerText.text = ConvertTimeToString(timer.TimeRemaining);
    }

    private string ConvertTimeToString(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return formattedTime;
    }

    private void ShowGameOverText()
    {
        timerText.text = "time over";
    }
}
