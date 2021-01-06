using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMovementController : MonoBehaviour
{
    [SerializeField] private bool removeAnimatorOnIdle;

    private MovingButton[] buttons;

    private void Start()
    {
        buttons = FindObjectsOfType<MovingButton>();
    }

    public void SetRemoveAnimators(bool doRemove)
    {
        removeAnimatorOnIdle = doRemove;
    }

    public void TriggerButtonsMovement()
    {
        foreach (var movingButton in buttons)
        {
            movingButton.RunAnimator(removeAnimatorOnIdle);
        }
    }
}
