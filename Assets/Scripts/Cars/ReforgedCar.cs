using UnityEngine;
using DG.Tweening;

public class ReforgedCar : CarBase
{
    [SerializeField] private float _sideSpeed;
    private Sequence _sequence;
    private bool _isPressed = false;

    private void Start()
    {
        
    }

    public override void Move(Vector3 direction)
    {
        if (direction.x != 0 && !_isPressed)
        {
            if (_sequence.active) _sequence.Kill();
            
            _isPressed = true;
            _sequence = DOTween.Sequence();
            _sequence.Append(_rigidbody.DOMoveX(direction.x * 5, _sideSpeed));
        }

        if (_isPressed && direction == Vector3.zero)
            _isPressed = false;
    }
}
