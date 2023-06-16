using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ContinueTimerButton : MonoBehaviour
{
    private Button continueTimerButton;
    public static event Action OnContinueTimerButtonClicked;

    private void Start()
    {
        continueTimerButton = GetComponent<Button>();
        continueTimerButton.onClick.AddListener(ContinueTimer);
    }

    private void ContinueTimer()
    {
        OnContinueTimerButtonClicked?.Invoke();
    }
}
