using UnityEngine;
using DG.Tweening;

public class ReforgedCar : CarBase
{
    [SerializeField] private float _lineChangeTime;
    [SerializeField] private Transform[] _linesPos;
    private int _currentLineId;
    private Sequence _sequence;
    private bool _isPressed = false;

    private void Start()
    {
        _currentLineId = _linesPos.Length / 2;
        transform.position = new Vector3(_linesPos[_currentLineId].position.x, transform.position.y, transform.position.z);
    }

    public override void Move(Vector3 direction)
    {
        if (direction.x != 0 && !_isPressed)
        {
            if (direction.x < 0 && _currentLineId == 0) return;
            if (direction.x > 0 && _currentLineId == _linesPos.Length - 1) return;

            if (_sequence != null && _sequence.active) _sequence.Kill();

            _currentLineId += (int)direction.x;
            _isPressed = true;
            _sequence = DOTween.Sequence();
            _sequence.Append(_rigidbody.DOMoveX(_linesPos[_currentLineId].position.x, _lineChangeTime));
        }

        if (_isPressed && direction == Vector3.zero)
            _isPressed = false;
    }

    private void OnDestroy()
    {
        _sequence.Complete();
    }
}
