using UnityEngine;
using UnityEngine.UI;

public class SelectByTouch : MonoBehaviour
{
    //test touch variables
    #region
    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    [SerializeField] private float displayTime = 0.5f;
    #endregion

    //test functions
    #region
    private void Test()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Ended)
            {
                phaseDisplayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }
            else if (Time.time - timeTouchEnded > displayTime)
            {
                phaseDisplayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }
        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
        }
    }
    #endregion


    //test 
    public void OnTouchSay()
    {
        Debug.Log("Button was touched");
    }
    private void Update()
    {
        //OnTouchChangeColor();
    }

}
