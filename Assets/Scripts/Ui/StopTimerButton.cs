using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StopTimerButton : MonoBehaviour
{
    private Button stopTimerButton;
    public static event Action OnStopTimerButtonClicked;

    private void Start()
    {
        stopTimerButton = GetComponent<Button>();
        stopTimerButton.onClick.AddListener(StopTimer);
    }

    private void StopTimer()
    {
        OnStopTimerButtonClicked?.Invoke();
    }
}
