using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimerUI : MonoBehaviour
{
    public TMP_Text countdownTimerText;

    public float countdownTime = 300f;
    public float currentTime;

    public static Action onCountdownFinished;

    private void Start()
    {
        StartTimer();
    }
    public void StartTimer()
    {
        currentTime = countdownTime;

        UpdateTime(currentTime);

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        currentTime--;

        if (currentTime > 0)
        {
            StartCoroutine(TimerCoroutine());
        }
        else if (currentTime == 0)
        {
            onCountdownFinished?.Invoke();
        }

        UpdateTime(currentTime);
    }

    private void UpdateTime(float targetValue)
    {
        int minutes = Mathf.FloorToInt(targetValue / 60);
        int seconds = Mathf.FloorToInt(targetValue % 60);
        countdownTimerText.text = $"{minutes:00}:{seconds:00}";
    }
}
