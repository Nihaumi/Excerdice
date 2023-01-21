using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] Canvas MainCanvas;
    [SerializeField] Canvas ExerciseListCanvas;
    [SerializeField] Canvas ExerciseCanvas;
    [SerializeField] Canvas SummaryCanvas;
    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject BtnBG;
    [SerializeField] GameObject MenuBar;
    [SerializeField] GameObject CompletetBtn;
    [SerializeField] GameObject Confetti;
    [SerializeField] Canvas OldCanvas;
    [SerializeField] Canvas ARCanvas = null;

    [SerializeField] GameObject homebtn;
    [SerializeField] GameObject exercisebtn;
    [SerializeField] GameObject socialsbtn;
    [SerializeField] private Color tmp_color;
    [SerializeField] private float start_opacity = 0.7f;
    [SerializeField] private float start_opacity_homebtn = 0.6f;
    [SerializeField] private float active_opacity = 1;
    [SerializeField] private Color start_value = new Color(216, 251, 255);
    [SerializeField] private Color active_value = new Color(130, 223, 233);

    //events
    public delegate void TimerDelegate();
    public static TimerDelegate ExerciseTimersUp;
    public static TimerDelegate ExerciseCanvas¡ctivation;

    public delegate void CanvasDelegate(Canvas canvas);
    public static CanvasDelegate MainSummCanavsActivated;
    public static CanvasDelegate MainSummCanavsDeactivated;

    public delegate void ARDelegate();
    public static ARDelegate ARActivation;
    public static ARDelegate ARDeActivation;

    //[SerializeField] GameObject SocialsCanvas;

    private void Start()
    {
        ActivateButtonBar();
        MenuBar.SetActive(true);
        MoveAllCanvas();
        MainCanvas.transform.position = new Vector3(0, 0, 0);
        OldCanvas = MainCanvas;

        ChangeOpacity(homebtn, active_opacity, active_value);
        ChangeOpacity(exercisebtn, start_opacity, start_value);
        ChangeOpacity(socialsbtn, start_opacity, start_value);
        Confetti.SetActive(false);

        ExerciseTimersUp += ShowCompletetBtn;
        WorkTimer.MainTimersUp += SwitchToExercise;
    }

    public void ChangeOpacity(GameObject obj, float opacity, Color value)
    {
        tmp_color = obj.GetComponent<Image>().color;
        //tmp_color = value;
        tmp_color.a = opacity;
        obj.GetComponent<Image>().color = tmp_color;
    }

    public void ShowCompletetBtn()
    {
        CompletetBtn.SetActive(true);
        //SwitchMenu(SummaryCanvas);
    }
    public void SwitchToExercise()
    {
        SwitchMenu(ExerciseListCanvas);
    }

    //canvas switching
    #region 
    public void SwitchMenu(Canvas canvas)
    {
        MoveAllCanvas();
        if (canvas.name == "Exercise")
        {
            DeavtivateButtonBar();
            ExerciseCanvas¡ctivation();
        }

        else if (OldCanvas.name == "Exercise")
        {
            ActivateButtonBar();
            CompletetBtn.SetActive(false);
        }

        if (canvas.name == "Exercise List")
        {
            ChangeOpacity(exercisebtn, active_opacity, active_value);
        }
        else if (OldCanvas.name == "Exercise List")
        {
            ChangeOpacity(exercisebtn, start_opacity, start_value);
        }
        if (canvas.name == "Summary")
        {
            Confetti.SetActive(true);
            MainSummCanavsActivated(canvas);
        }
        else if (OldCanvas.name == "Summary")
        {
            Confetti.SetActive(false);
            MainSummCanavsDeactivated(canvas);
        }
        if (canvas.name == "Main")
        {
            MainSummCanavsActivated(canvas);
            ChangeOpacity(homebtn, active_opacity, active_value);
        }
        else if (OldCanvas.name == "Main")
        {
            MainSummCanavsDeactivated(canvas);
            ChangeOpacity(homebtn, start_opacity_homebtn, start_value);
        }
        if (canvas.name == "AR")
        {
            ARActivation();
        }
        else if (OldCanvas.name == "AR")
        {
            ARDeActivation();
        }
        canvas.transform.position = new Vector3(0, 0, 0);
        OldCanvas = canvas;
    }

    public void DeavtivateButtonBar()
    {
        Buttons.SetActive(false);
        BtnBG.SetActive(false);
    }

    public void ActivateButtonBar()
    {
        Buttons.SetActive(true);
        BtnBG.SetActive(true);
    }

    private void MoveAllCanvas()
    {
        MainCanvas.transform.position = new Vector3(1251, 0, 0);
        ExerciseCanvas.transform.position = new Vector3(1251, 0, 0);
        ExerciseListCanvas.transform.position = new Vector3(1251, 0, 0);
        SummaryCanvas.transform.position = new Vector3(1251, 0, 0);
        ARCanvas.transform.position = new Vector3(1251, 0, 0);
    }
    #endregion


}
