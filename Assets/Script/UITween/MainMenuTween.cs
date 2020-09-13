using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuTween : MonoBehaviour
{
    public Button[] buttonList;

    private void OnEnable()
    {
        foreach(Button button in buttonList)
        {
            if(button.GetComponent<ButtonTween>() != null)
            {
                button.GetComponent<ButtonTween>().EnlargeButton();
            }
        }
    }
}
