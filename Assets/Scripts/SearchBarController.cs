using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBarController : MonoBehaviour
{
    public void OnInputTap()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
