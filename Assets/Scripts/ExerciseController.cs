using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ExerciseController : MonoBehaviour
{
    //buttons
    [SerializeField] GameObject PlayBtn;
    [SerializeField] GameObject PauseBtn;
    [SerializeField] GameObject SkipBtn;

    //timer
    public TMP_Text timerText;
    [SerializeField] public float startTimer = 900f;
    [SerializeField] private float timer = 0;
    //events
    [SerializeField] private bool has_timer_started = false;
    [SerializeField] private bool has_timer_paused = false;

    //animated cubes
    [SerializeField] private GameObject MainCube;
    [SerializeField] private GameObject SummCube;

    // Start is called before the first frame update
    void Start()
    {
        PauseBtn.SetActive(false);
        SummCube.GetComponent<Animator>().enabled = false;
        ButtonLogic.MainSummCanavsActivated += StartAnimation;
        ButtonLogic.MainSummCanavsDeactivated += StopAnimation;
        //CalculateTimer();
    }

    //animations
    #region
    public void StartAnimation(Canvas canvas)
    {
        if (canvas.name == "Main")
        {
            MainCube.GetComponent<Animator>().enabled = true;
        }
        else if (canvas.name == "Summary")
        {
            SummCube.GetComponent<Animator>().enabled = true;
        }
        else
        {
            Debug.LogWarning("invalid Call - canvas event should only truigger for exercise or summary");
        }
    }
    public void StopAnimation(Canvas canvas =null)
    {
        MainCube.GetComponent<Animator>().enabled = false;
        SummCube.GetComponent<Animator>().enabled = false;
    }
    #endregion

    //skip/Pause/PLay button functionalities
    #region
    public void SkipExercise()
    {
        timer = 0;
        has_timer_started = false;
        has_timer_paused = false;
        ButtonLogic.ExerciseTimersUp();
    }

    public void StartTimer()
    {
        if (!has_timer_started)
            timer = startTimer;
        has_timer_started = true;
        has_timer_paused = false;

        PlayBtn.SetActive(false);
        PauseBtn.SetActive(true);
    }

    public void PauseTimer()
    {
        has_timer_paused = true;

        PlayBtn.SetActive(true);
        PauseBtn.SetActive(false);
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        if (has_timer_started && !has_timer_paused)
            CalculateTimer();
    }

    public void CalculateTimer()
    {
        if (timer <= 0.01f)
        {
            ButtonLogic.ExerciseTimersUp();
            has_timer_started = false;
            return;
        }
        timer -= Time.deltaTime;

        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = timerString;
    }
}
