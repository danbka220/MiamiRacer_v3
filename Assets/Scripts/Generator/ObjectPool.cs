using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
{
    public bool HaveObjects { get => _pooledObjects.Count != 0; }
    private List<T> _pooledObjects = new List<T>();

    public T GetRandom()
    {
        T go = _pooledObjects[Random.Range(0, _pooledObjects.Count)];
        _pooledObjects.Remove(go);
        return go;
    }

    public void Put(T go)
    {
        _pooledObjects.Add(go);
    }
}
