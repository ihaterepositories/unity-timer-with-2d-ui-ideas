using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerText : MonoBehaviour
{
    private Text timerText;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        Timer.OnTimerWorking += TimeToText;
        Timer.OnTimerFinish += SetTimeOverText;
    }

    private void OnDisable()
    {
        Timer.OnTimerWorking -= TimeToText;
        Timer.OnTimerFinish -= SetTimeOverText;
    }

    private void TimeToText(float timeRemaining, float duration)
    {
        if (timeRemaining is not 0f && timeRemaining <= duration)
        {
            timerText.text = ConvertTimeToString(timeRemaining);
        }
    }

    private string ConvertTimeToString(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        return formattedTime;
    }

    private void SetTimeOverText()
    {
        timerText.text = "GAME OVER";
    }
}
