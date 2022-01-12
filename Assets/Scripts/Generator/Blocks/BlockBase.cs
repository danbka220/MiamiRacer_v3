using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockBase : MonoBehaviour
{
    [SerializeField] private MeshFilter _mesh;
    [HideInInspector] public float SpawnChance = 50;
    public float ZSize => _zsize;
    private float _zsize;

    private void Awake()
    {
        Mesh mesh = _mesh.sharedMesh;
        _zsize = mesh.bounds.size.z;
    }
}
