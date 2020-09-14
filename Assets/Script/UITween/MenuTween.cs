using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuTween : MonoBehaviour
{
    [Header("Buttons")]
    public ButtonTween[] list;

    [Header("Panel")]
    public GameObject panel;
    public bool startingPanel;

    [Header("Move Panel Up")]
    public float upPos;
    public float upDuration;
    public Ease upEase;

    [Header("Move Panel Down")]
    public float downPos;
    public float downDuration;
    public Ease downEase;

    [Header("Scale Panel")]
    public float scaleValue;
    public float scaleDuration;
    public Ease scaleEase;

    private void OnEnable()
    {
        if (startingPanel)
        {
            EnlargeButtons();
        }
    }

    public void MoveUp()
    {
        panel.SetActive(true);
        panel.transform.DOLocalMoveY(upPos, upDuration).SetEase(upEase).OnComplete(EnlargeButtons);
    }

    public void MoveDown()
    {
        ShrinkButton();
        panel.transform.DOLocalMoveY(downPos, downDuration).SetEase(downEase).OnComplete(() => gameObject.SetActive(false));
    }

    public void ScalePanel()
    {
        panel.transform.DOScale(scaleValue, scaleDuration).SetEase(scaleEase);
    }

    public void EnlargeButtons()
    {
        foreach (ButtonTween button in list)
        {
            button.EnlargeButton();
        }
    }

    public void ShrinkButton()
    {
        foreach (ButtonTween button in list)
        {
            button.ShrinkButton();
        }
    }
}
