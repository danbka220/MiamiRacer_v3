using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonWeightedPool<T> : ObjectPool<T> where T : BlockBase
{
    private List<T> _objects = new List<T>();
    public override bool HaveObjects => _objects.Count > 0;

    public override T GetRandom()
    {
        T obj = _objects[Random.Range(0, _objects.Count)];
        _objects.Remove(obj);
        return obj;
    }

    public override void Put(T go)
    {
        _objects.Add(go);
    }
}
