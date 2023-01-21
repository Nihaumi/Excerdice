using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARHandler : MonoBehaviour
{
    [SerializeField] Canvas ARCanvas;
    [SerializeField] GameObject ARObj;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject ARCam;
    [SerializeField] GameObject RewardList;
    [SerializeField] private bool rewards_are_visible;

    private void Start()
    {
        ARObj.SetActive(false);
        HideRewards();
        ButtonLogic.ARActivation += EnableARObj;
        ButtonLogic.ARDeActivation += DisableARObj;
    }

    public void EnableARObj()
    {
        ARObj.SetActive(true);
        MainCamera.SetActive(false);
    }
    
    public void DisableARObj()
    {
        ARObj.SetActive(false);
        MainCamera.SetActive(true);
    }

    public void ToggleRewards()
    {
        if (rewards_are_visible)
        {
            HideRewards();
        }
        else if (!rewards_are_visible)
        {
            ShowRewards();
        }
    }

    public void ShowRewards()
    {
        RewardList.SetActive(true);
        rewards_are_visible = true;
    } 
    public void HideRewards()
    {
        RewardList.SetActive(false);
        rewards_are_visible = false;
    }
}
