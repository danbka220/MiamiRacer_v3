using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ActionButtonLinker : MonoBehaviour
{
    [SerializeField] private List<ActionsHandler.Actions> _actions = new List<ActionsHandler.Actions>();

    private ActionsHandler _handler;
    private Button _button;

    private void Awake()
    {
        _handler = FindObjectOfType<ActionsHandler>();

        TryGetComponent<Button>(out _button);
    }

    private void OnEnable()
    {
        if (_button)
            _button.onClick.AddListener(InvokeActions);
    }

    private void OnDisable()
    {
        if (_button)
            _button.onClick.RemoveListener(InvokeActions);
    }

    private void InvokeActions()
    {
        foreach (ActionsHandler.Actions action in _actions)
        {
            switch (action)
            {
                case ActionsHandler.Actions.OnPauseClickAction: _handler.OnPauseClickAction?.Invoke(); break;
            }
        }
    }
}
