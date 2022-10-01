using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionsHandler : MonoBehaviour
{
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

        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
