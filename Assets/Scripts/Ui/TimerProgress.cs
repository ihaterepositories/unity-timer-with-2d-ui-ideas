using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimerProgress : MonoBehaviour
{
    [SerializeField] private bool isReversed;
    private Image progressImage;

    private void Start()
    {
        progressImage = GetComponent<Image>();

        if (isReversed)
        {
            SetFullFillAmount();
        }
        else
        {
            SetEmptyFillAmount();
        }
    }

    private void OnEnable()
    {
        if (isReversed)
        {
            Timer.OnTimerStart += SetFullFillAmount;
            Timer.OnTimerWorking += ChangeFillAmountReversed;
            Timer.OnTimerFinish += SetEmptyFillAmount;
        }
        else
        {
            Timer.OnTimerStart += SetEmptyFillAmount;
            Timer.OnTimerWorking += CahngeFillAmount;
            Timer.OnTimerFinish += SetFullFillAmount;
        }
    }

    private void OnDisable()
    {
        if (isReversed)
        {
            Timer.OnTimerStart -= SetFullFillAmount;
            Timer.OnTimerWorking -= ChangeFillAmountReversed;
            Timer.OnTimerFinish -= SetEmptyFillAmount;
        }
        else
        {
            Timer.OnTimerStart -= SetEmptyFillAmount;
            Timer.OnTimerWorking -= CahngeFillAmount;
            Timer.OnTimerFinish -= SetFullFillAmount;
        }
    }

    private void CahngeFillAmount(float timeRemaining, float duration)
    {
        if (timeRemaining is not 0f && timeRemaining <= duration)
        {
            progressImage.fillAmount = (duration - timeRemaining) / duration;
        }
    }

    private void ChangeFillAmountReversed(float timeRemaining, float duration)
    {
        if (timeRemaining is not 0f && timeRemaining <= duration)
        {
            progressImage.fillAmount = ((timeRemaining - duration) / duration) + 1;
        }
    }

    private void SetFullFillAmount()
    {
        progressImage.fillAmount = 1f;
    }

    private void SetEmptyFillAmount()
    {
        progressImage.fillAmount = 0f;
    }
}
