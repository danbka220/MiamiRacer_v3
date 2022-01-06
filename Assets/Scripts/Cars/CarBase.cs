using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CarBase : MonoBehaviour, IMovable
{
    [SerializeField]
    protected float _speed;

    protected Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public abstract void Move(Vector3 direction);
}
