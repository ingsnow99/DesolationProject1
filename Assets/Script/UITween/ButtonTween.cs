using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonTween : MonoBehaviour
{
    public bool initScale0;

    [Header("Enlarge")]
    public float enlargeValue;
    public float enlargeDuration;
    public Ease enlargeEase;

    [Header("Shrink")]
    public float shrinkValue;
    public float shrinkDuration;
    public Ease shrinkEase;

    [Header("Move Right")]
    public float rightPos;
    public float rightDuration;
    public Ease rightEase;

    private void Start()
    {
        if (initScale0)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void EnlargeButton()
    {
        gameObject.transform.DOScale(enlargeValue, enlargeDuration).SetEase(enlargeEase);
    }

    public void ShrinkButton()
    {
        gameObject.transform.DOScale(shrinkValue, shrinkDuration).SetEase(shrinkEase);
    }

    public void MoveRight()
    {
        gameObject.transform.DOLocalMoveX(rightPos, rightDuration).SetEase(rightEase);
    }
}
