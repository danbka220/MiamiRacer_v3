using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private GameObject _movableObject;

    private IMovable _movable;

    private void Awake()
    {
        if (!_movableObject.TryGetComponent(out _movable))
            throw new NullReferenceException();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        _movable.Move(input);
    }
}
