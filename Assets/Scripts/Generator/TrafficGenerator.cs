using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficGenerator : ObjectGenerator<TrafficBlock>
{
    [SerializeField] private Transform[] _lines;
    [SerializeField] private float _minSpace;
    [SerializeField] private float _maxSpace;

    private WeightedPool<TrafficBlock> _pool = new WeightedPool<TrafficBlock>();
    protected override ObjectPool<TrafficBlock> Pool => _pool;

    protected override void Spawn()
    {
        if (!_pool.HaveObjects) return;

        TrafficBlock go = _pool.GetRandom();

        if (_instantiated.Count != 0)
        {
            float space = Random.Range(_minSpace, _maxSpace);

            TrafficBlock lastBlock = _instantiated[_instantiated.Count - 1];
            float zpos = lastBlock.transform.position.z + (lastBlock.ZSize / 2) + (go.ZSize / 2) + space;
            Vector3 pos = new Vector3(_lines[Random.Range(0, _lines.Length)].position.x, transform.position.y, zpos);
            go.transform.position = pos;
        }
        else
        {
            go.transform.position = transform.position;
        }

        go.gameObject.SetActive(true);
        _instantiated.Add(go);
    }

    protected override void Despawn()
    {
        TrafficBlock go = _instantiated[0];
        _instantiated.Remove(go);
        _pool.Put(go);
        go.gameObject.SetActive(false);
    }
}
