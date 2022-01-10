using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : ObjectGenerator
{
    [SerializeField] private float _spacing;

    protected override void Spawn()
    {
        if (!_pool.HaveObjects) return;

        BlockBase go = _pool.GetRandom(); 

        if (_instantiated.Count != 0)
        {
            BlockBase lastBlock = _instantiated[_instantiated.Count - 1];
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

    protected override void Despawn()
    {
        BlockBase go = _instantiated[0];
        _instantiated.Remove(go);
        _pool.Put(go);
        go.gameObject.SetActive(false);
    }
}
