using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmGenerator : ObjectGenerator<PalmBlock>
{
    [SerializeField] private float _minSpace;
    [SerializeField] private float _maxSpace;
    [SerializeField] private Transform _leftWall;
    [SerializeField] private Transform _rightWall;

    private NonWeightedPool<PalmBlock> _pool = new NonWeightedPool<PalmBlock>();
    protected override ObjectPool<PalmBlock> Pool => _pool;

    protected override void Spawn()
    {
        SpawnPalm(_minSpace, _maxSpace);
    }

    private void SpawnPalm(float minSpace, float maxSpace)
    {
        if (!_pool.HaveObjects) return;

        PalmBlock go = _pool.GetRandom();

        if (_instantiated.Count != 0)
        {
            PalmBlock lastBlock = _instantiated[_instantiated.Count - 1];

            float space = Random.Range(minSpace, maxSpace);
            float zpos;
            zpos = lastBlock.transform.position.z + space;

            Vector3 pos = new Vector3(Random.Range(_leftWall.transform.position.x, _rightWall.position.x), transform.position.y, zpos);
            go.transform.position = pos;
        }
        else
        {
            go.transform.position = new Vector3(Random.Range(_leftWall.transform.position.x, _rightWall.position.x), transform.position.y, transform.position.z);
        }

        Ray ray = new Ray(new Vector3(go.transform.position.x, go.transform.position.y, _car.transform.position.z), Vector3.down);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            go.transform.position = go.transform.position + new Vector3(0,hit.point.y - .5f,0);
        }

        go.transform.Rotate(new Vector3(0,Random.Range(0,360)));

        go.gameObject.SetActive(true);
        _instantiated.Add(go);
    }
}
