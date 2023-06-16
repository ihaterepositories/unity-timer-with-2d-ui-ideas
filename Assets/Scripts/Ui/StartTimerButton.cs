using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartTimerButton : MonoBehaviour
{
    private Button startTimerButton;
    public static event Action OnStartTimerButtonClicked;

    private void Start()
    {
        startTimerButton = GetComponent<Button>();
        startTimerButton.onClick.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        OnStartTimerButtonClicked?.Invoke();
    }
}
