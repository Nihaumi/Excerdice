using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class WorkTimer : MonoBehaviour
{
    public TMP_Text timerText;
    [SerializeField] public float startTimer = 9000f;
    [SerializeField] private float timer = 0;

    [SerializeField] private bool timer_has_ended = false;

    public delegate void MainTimerDelegate();
    public static MainTimerDelegate MainTimersUp;

    private void Start()
    {
        timer = startTimer;
        CalculateTimer();

        ButtonLogic.ExerciseTimersUp += RestartTimer;
    }

    private void Update()
    {
        if (!timer_has_ended)
            CalculateTimer();
    }

    public void RestartTimer()
    {
        timer = startTimer;
        timer_has_ended = false;
    }

    public void CalculateTimer()
    {
        if (timer <= 0.01f)
        {
            MainTimersUp();
            timer_has_ended = true;
            return;
        }
        timer -= Time.deltaTime;

        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 60;

        string timerString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        timerText.text = timerString;
    }
}
