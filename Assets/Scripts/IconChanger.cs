using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconChanger : MonoBehaviour
{
    public void ChangeIcon(GameObject btn)
    {
        btn.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
