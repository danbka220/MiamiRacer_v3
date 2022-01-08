using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private CarBase _car;
    [SerializeField] private GameObject[] _objects;
    private List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(_objects[Random.Range(0, _objects.Length)], transform);
            if (_spawnedObjects.Count != 0)
            {
                Mesh mesh = _spawnedObjects[_spawnedObjects.Count - 1].GetComponent<MeshFilter>().sharedMesh;
                float posz = _spawnedObjects[_spawnedObjects.Count - 1].transform.position.z + mesh.bounds.size.z;
                go.transform.position = new Vector3(transform.position.x, transform.position.y, posz);
            }
            else
            {
                go.transform.position = transform.position;
            }
            _spawnedObjects.Add(go);
        }
    }

    private void Update()
    {
        if(_car.transform.position.z - _spawnedObjects[0].transform.position.z > 20f)
        {
            Destroy(_spawnedObjects[0]);
            _spawnedObjects.RemoveAt(0);
            GameObject go = Instantiate(_objects[Random.Range(0, _objects.Length)], transform);
            Mesh mesh = _spawnedObjects[_spawnedObjects.Count - 1].GetComponent<MeshFilter>().sharedMesh;
            float posz = _spawnedObjects[_spawnedObjects.Count - 1].transform.position.z + mesh.bounds.size.z;
            go.transform.position = new Vector3(transform.position.x, transform.position.y, posz);
            _spawnedObjects.Add(go);
        }
    }
}
