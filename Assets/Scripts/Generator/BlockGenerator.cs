using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : ObjectGenerator<StandartBlock>
{
    [SerializeField] private float _spacing;
    [SerializeField] private NonWeightedPool<StandartBlock> _pool = new NonWeightedPool<StandartBlock>();
    protected override ObjectPool<StandartBlock> Pool => _pool;

    protected override void Spawn()
    {
        if (!_pool.HaveObjects) return;

        StandartBlock go = _pool.GetRandom(); 

        if (_instantiated.Count != 0)
        {
            StandartBlock lastBlock = _instantiated[_instantiated.Count - 1];
            float zpos = lastBlock.transform.position.z + lastBlock.ZSize;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, zpos + _spacing);
            go.transform.position = pos;
        }
        else
        {
            go.transform.position = transform.position;
        }

        go.gameObject.SetActive(true);
        _instantiated.Add(go);
    }
}
