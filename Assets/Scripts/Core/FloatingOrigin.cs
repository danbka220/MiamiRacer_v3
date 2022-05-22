using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingOrigin : MonoBehaviour
{
    [SerializeField] private Transform _referenceTransform;
    [SerializeField] private float _threshold = 100f;
    [SerializeField] private Transform[] _transformsToMove;

    private void FixedUpdate()
    {
        Vector3 refPosition = _referenceTransform.position;

        if(refPosition.sqrMagnitude >= _threshold * _threshold)
        {
            MoveOrigin(refPosition);
        }
    }

    private void MoveOrigin(Vector3 offset)
    {
        for (int i = 0; i < _transformsToMove.Length; i++)
        {
            _transformsToMove[i].position -= new Vector3(0, 0, offset.z);
        } 
    }
}
