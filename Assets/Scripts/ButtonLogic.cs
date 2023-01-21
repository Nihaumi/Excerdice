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
    [SerializeField] GameObject Confetti;
    [SerializeField] Canvas OldCanvas;
    [SerializeField] Canvas ARCanvas = null;

    [SerializeField] GameObject homebtn_grey;
    [SerializeField] GameObject homebtn_color;
    [SerializeField] GameObject exercisebtn_color;
    [SerializeField] GameObject exercisebtn_grey;

    //events
    public delegate void TimerDelegate();
    public static TimerDelegate ExerciseTimersUp;

    public delegate void CanvasDelegate(Canvas canvas);
    public static CanvasDelegate MainSummCanavsActivated;
    public static CanvasDelegate MainSummCanavsDeactivated;

    public delegate void ARDelegate();
    public static ARDelegate ARActivation;
    public static ARDelegate ARDeActivation;

    //[SerializeField] GameObject SocialsCanvas;

    private void Start()
    {
        MoveAllCanvas();
        MainCanvas.transform.position = new Vector3(0, 0, 0);
        OldCanvas = MainCanvas;

        DisbaleColorIcons();
        homebtn_color.SetActive(true);
        homebtn_grey.SetActive(false);
        Confetti.SetActive(false);

        ExerciseTimersUp += SwitchToSummary;
        WorkTimer.MainTimersUp += SwitchToExercise;
    }

    private void DisbaleColorIcons()
    {
        homebtn_color.SetActive(false);
        exercisebtn_color.SetActive(false);
    }

    public void SwitchToSummary()
    {
        SwitchMenu(SummaryCanvas);
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
        }

        else if (OldCanvas.name == "Exercise")
        {
            ActivateButtonBar();
        }

        if(canvas.name == "Exercise List")
        {
            exercisebtn_color.SetActive(true);
            exercisebtn_grey.SetActive(false);
        }
        else if(OldCanvas.name == "Exercise List")
        {
            exercisebtn_color.SetActive(false);
            exercisebtn_grey.SetActive(true);
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
            homebtn_color.SetActive(true);
            homebtn_grey.SetActive(false);
        }
        else if (OldCanvas.name == "Main")
        {
            MainSummCanavsDeactivated(canvas);
            homebtn_color.SetActive(false);
            homebtn_grey.SetActive(true);
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
