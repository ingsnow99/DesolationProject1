using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelMenuTween : MonoBehaviour
{
    [Header("Buttons")]
    public ButtonTween[] buttonList;

    [Header("Scale")]
    public float scaleValue;
    public float scaleDuration;
    public Ease scaleEase;

    private void OnEnable()
    {
        ScaleButtons();
    }

    public void ScalePanel()
    {
        gameObject.transform.DOScale(scaleValue, scaleDuration).SetEase(scaleEase);
    }

    public void ScaleButtons()
    {
        foreach(ButtonTween button in buttonList)
        {
            button.EnlargeButton();
        }
    }
}
