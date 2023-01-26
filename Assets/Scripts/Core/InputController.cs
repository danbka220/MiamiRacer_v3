using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _movableObject;

    private IMovable _movable;
    private ActionsHandler _actions;

    private void Start()
    {
        if (!_movableObject.TryGetComponent(out _movable))
            throw new NullReferenceException();

        _actions = FindObjectOfType<ActionsHandler>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            _movable.Move(input);
        }

        if(_actions)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                _actions.InvokeAction(_actions.OnPauseClickAction);
            }
        }
    }
}
