using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Video;

public class ExerciseController : MonoBehaviour
{
    //buttons
    [SerializeField] GameObject PlayBtn;
    [SerializeField] GameObject PauseBtn;
    [SerializeField] GameObject SkipBtn;
    [SerializeField] GameObject CompleteBtn;

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

    //Exercise Video
    private VideoPlayer video_player;
    [SerializeField] GameObject VideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        PauseBtn.SetActive(false);
        PlayBtn.SetActive(true);
        SkipBtn.SetActive(true);
        CompleteBtn.SetActive(false);
        SummCube.GetComponent<Animator>().enabled = false;
        ButtonLogic.MainSummCanavsActivated += StartAnimation;
        ButtonLogic.MainSummCanavsDeactivated += StopAnimation;
        ButtonLogic.ExerciseCanvas¡ctivation += SetUP;
        ButtonLogic.ExerciseTimersUp += HideButtons;
        //CalculateTimer();

        //Exercise Video
        video_player = VideoPlayer.GetComponent<VideoPlayer>();
        video_player.frame = 0;
    }

    private void SetUP()
    {
        PauseBtn.SetActive(false);
        PlayBtn.SetActive(true);
        SkipBtn.SetActive(true);
        CompleteBtn.SetActive(false);
        SummCube.GetComponent<Animator>().enabled = true;
        has_timer_started = false;
        has_timer_paused = false;
        video_player.Pause();
        video_player.frame = 0;
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
    public void StopAnimation(Canvas canvas = null)
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
        video_player.frame = 0;
        video_player.Stop();
    }

    public void StartTimer()
    {
        if (!has_timer_started)
            timer = startTimer;
        has_timer_started = true;
        has_timer_paused = false;

        PlayBtn.SetActive(false);
        PauseBtn.SetActive(true);
        video_player.Play();
    }

    public void PauseTimer()
    {
        has_timer_paused = true;

        PlayBtn.SetActive(true);
        PauseBtn.SetActive(false);
        video_player.Stop();
    }

    public void HideButtons()
    {
        PlayBtn.SetActive(false);
        PauseBtn.SetActive(false);
        SkipBtn.SetActive(false);
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        if (has_timer_started && !has_timer_paused)
            CalculateTimer();
    }

    public void ShowCompletetdBtn()
    {
        PlayBtn.SetActive(false);
        PauseBtn.SetActive(false);
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
