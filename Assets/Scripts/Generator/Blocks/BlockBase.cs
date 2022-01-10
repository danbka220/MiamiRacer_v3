using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockBase : MonoBehaviour
{
    public float ZSize => _zsize;
    private float _zsize;

    private void Awake()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        _zsize = mesh.bounds.size.z;
    }
}
