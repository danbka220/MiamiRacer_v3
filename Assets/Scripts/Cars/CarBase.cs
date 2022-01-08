using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CarBase : MonoBehaviour, IMovable
{
    [SerializeField] protected float _speed;

    protected Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveForward(_speed);
    }

    private void MoveForward(float speed)
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, speed * Time.deltaTime);
    }

    public abstract void Move(Vector3 direction);
}
