using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameWindowsController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;

    private ActionsHandler _actions;

    private void Start()
    {
        _actions = FindObjectOfType<ActionsHandler>();

        if(_actions)
            _actions.OnPauseClickAction += TogglePauseWindow;
    }

    private void OnDestroy()
    {
        if(_actions)
            _actions.OnPauseClickAction -= TogglePauseWindow;
    }

    private void TogglePauseWindow()
    {
        if (!_actions) return;

        _pauseWindow.SetActive(!_pauseWindow.activeInHierarchy);
    }
}
