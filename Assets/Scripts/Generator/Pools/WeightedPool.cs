using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPool<T> : ObjectPool<T> where T : BlockBase
{
    private List<T> _objects = new List<T>();
    private float _totalValue = 0;

    public override bool HaveObjects => _objects.Count > 0;

    public override T GetRandom()
    {
        float weight = 0;
        float random = Random.value;
        T obj = null;

        for(int index = 0; index < _objects.Count; index++)
        {
            if(_objects[index].SpawnChance / _totalValue + weight >= random)
            {
                obj = _objects[index];
                break;
            }
            else
            {
                weight += _objects[index].SpawnChance / _totalValue;
            }
        }

        _objects.Remove(obj);
        _totalValue -= obj.SpawnChance;
        return obj;
    }

    public override void Put(T go)
    {
        _objects.Add(go);
        _totalValue += go.SpawnChance;
    }
}
