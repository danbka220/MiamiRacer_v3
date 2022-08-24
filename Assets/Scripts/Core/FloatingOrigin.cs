using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingOrigin : MonoBehaviour
{
    [SerializeField] private Transform _referenceTransform;
    [SerializeField] private float _threshold = 100f;
    [SerializeField] private TransformToMove[] _transformsToMove;

    private void FixedUpdate()
    {
        Vector3 refPosition = _referenceTransform.position;

        if (refPosition.sqrMagnitude >= _threshold * _threshold)
        {
            MoveOrigin(refPosition);
        }
    }

    private void MoveOrigin(Vector3 offset)
    {
        for (int i = 0; i < _transformsToMove.Length; i++)
        {
            if (_transformsToMove[i].ShiftChildrens)
            {
                for (int t = 0; t < _transformsToMove[i].Transform.childCount; t++)
                {
                    _transformsToMove[i].Transform.GetChild(t).transform.position -= new Vector3(0, 0, offset.z);
                }
            }
            else
            {
                _transformsToMove[i].Transform.position -= new Vector3(0, 0, offset.z);
            }
        }
    }

    [System.Serializable]
    internal class TransformToMove
    {
        public Transform Transform;
        public bool ShiftChildrens = false;
    }
}
