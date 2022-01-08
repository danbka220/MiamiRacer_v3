using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingOrigin : MonoBehaviour
{
    [SerializeField]
    private Transform _referenceTransform;
    [SerializeField]
    private float _threshold = 100f;

    private void FixedUpdate()
    {
        Vector3 refPosition = _referenceTransform.position;

        if(refPosition.magnitude > _threshold)
        {
            MoveOrigin(refPosition);
        }
    }

    private void MoveOrigin(Vector3 offset)
    {
        foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
            g.transform.position -= new Vector3(0,0,offset.z);
    }
}
