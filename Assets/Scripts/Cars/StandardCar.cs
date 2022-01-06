using UnityEngine;

public class StandardCar : CarBase
{
    public override void Move(Vector3 direction)
    {
        _rigidbody.velocity = new Vector3(_speed * direction.x,0, _speed * 10);
    }
}
