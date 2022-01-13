using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrafficGenerator : ObjectGenerator<TrafficBlock>
{
    [SerializeField] private Transform[] _lines;
    [SerializeField] private float _minSpace;
    [SerializeField] private float _maxSpace;

    private WeightedPool<TrafficBlock> _pool = new WeightedPool<TrafficBlock>();
    protected override ObjectPool<TrafficBlock> Pool => _pool;
    private List<Transform> _exclusiveLines = new List<Transform>();

    protected override void Spawn()
    {
        _exclusiveLines.Clear();
        SpawnCar(_minSpace, _maxSpace);
    }

    private void SpawnCar(float minSpace, float maxSpace, bool partner = false)
    {
        if (!_pool.HaveObjects) return;

        TrafficBlock go = _pool.GetRandom();
        Transform line = GetRandomLine();

        if (_instantiated.Count != 0)
        {
            TrafficBlock lastBlock = _instantiated[_instantiated.Count - 1];

            float space = Random.Range(minSpace, maxSpace);
            float zpos;
            if (!partner)
                zpos = lastBlock.transform.position.z + (lastBlock.ZSize / 2) + (go.ZSize / 2) + space;
            else
                zpos = lastBlock.transform.position.z + space;

            Vector3 pos = new Vector3(line.position.x, transform.position.y, zpos);
            go.transform.position = pos;
        }
        else
        {
            go.transform.position = new Vector3(line.position.x, transform.position.y, transform.position.z);
        }

        go.gameObject.SetActive(true);
        _instantiated.Add(go);
        _exclusiveLines.Add(line);

        if(_exclusiveLines.Count < _lines.Length - 1 && Random.Range(0,2) == 1)
        {
            SpawnCar(0f, 10f, true);
        }
    }

    private Transform GetRandomLine()
    {
        Transform line = _lines[Random.Range(0, _lines.Length)];

        while(true)
        {
            if (_exclusiveLines.Contains(line))
                line = _lines[Random.Range(0, _lines.Length)];
            else
                return line;
        }
    }

    private Transform GetRandomLine(Transform[] exclusive)
    {
        int rand = Random.Range(0, _lines.Length);
        Transform line = _lines[rand];
        if (exclusive.Contains(line)) return GetRandomLine(exclusive);
        else return line;
    }
}
