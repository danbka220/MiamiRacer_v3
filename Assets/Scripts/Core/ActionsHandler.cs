using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionsHandler : MonoBehaviour
{
    
    public enum Actions
    {
        OnPauseClickAction
    }

    public UnityAction OnPauseClickAction;
    public bool ActionsLocked { get; private set; } = false;

    private void Awake()
    {
        OnPauseClickAction += OnPauseClicked;
    }

    private void OnDestroy()
    {
        OnPauseClickAction -= OnPauseClicked;
    }

    public void LockActions()
    {
        ActionsLocked = true;
    }

    public void FreezeTime()
    {
        Time.timeScale = 0;
    }

    public void UnfreezeTime()
    {
        Time.timeScale = 1;
    }

    public void UnlockActions()
    {
        ActionsLocked = false;
    }

    public void InvokeAction(UnityAction action)
    {
        if (ActionsLocked) return;

        if(action == OnPauseClickAction)
            OnPauseClickAction?.Invoke();
    }

    private void OnPauseClicked()
    {
        if (ActionsLocked) return;

        if (Time.timeScale == 0)
            UnfreezeTime();
        else
            FreezeTime();
    }
}
