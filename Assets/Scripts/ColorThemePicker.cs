using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorThemePicker : MonoBehaviour
{
    [SerializeField] Image UpperImage;
    [SerializeField] Image BottomImage;
    [SerializeField] private Color red_up;
    [SerializeField] private Color red_down;
    [SerializeField] private Color blue_up;
    [SerializeField] private Color blur_down;
    [SerializeField] private Color green_up;
    [SerializeField] private Color green_down;
    enum ColorTheme
    {
        Red,
        Blue,
        Green,
    };

    [SerializeField] ColorTheme colorTheme;


    private void Start()
    {
        red_up = new Color32(180, 68, 37, 255);
        red_down = new Color32(229, 198, 109, 255);

        blue_up = new Color32(55, 71, 194, 255);
        blur_down = new Color32(109, 229, 109, 255);

        green_up = new Color32(91, 185, 71, 255);
        green_down = new Color32(229, 227, 109, 255);

        colorTheme = ColorTheme.Blue;
    }

    void ThemeChanger()
    {
        switch (colorTheme)
        {
            case ColorTheme.Red:
                UpperImage.color = red_up;
                BottomImage.color = red_down;
                break;

            case ColorTheme.Blue:
                UpperImage.color = blue_up;
                BottomImage.color = blur_down;
                break;
            case ColorTheme.Green:
                UpperImage.color = green_up;
                BottomImage.color = green_down;
                break;
        }
    }
    private void Update()
    {
        ThemeChanger();
    }

}
