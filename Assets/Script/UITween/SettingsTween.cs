using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsTween : MonoBehaviour
{
    [Header("Buttons")]
    public ButtonTween[] list;

    [Header("Move Up")]
    public float upPos;
    public float upDuration;
    public Ease upEase;

    [Header("Move Down")]
    public float downPos;
    public float downDuration;
    public Ease downEase;


    public void MoveUp()
    {
        gameObject.SetActive(true);
        gameObject.transform.DOLocalMoveY(upPos, upDuration).SetEase(upEase).OnComplete(EnlargeButtons);
    }

    public void MoveDown()
    {
        foreach (ButtonTween button in list)
        {
            button.ShrinkButton();
        }
        gameObject.transform.DOLocalMoveY(downPos, downDuration).SetEase(downEase).OnComplete(()=>gameObject.SetActive(false));
    }

    public void EnlargeButtons()
    {
        foreach (ButtonTween button in list)
        {
            button.EnlargeButton();
        }
    }

}
