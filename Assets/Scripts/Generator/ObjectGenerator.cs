using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private CarBase _car;
    [SerializeField] private AssetReferenceT<ObjectsData> _factory;
    [SerializeField] private int _instanceCount;
    [SerializeField] private int _pooledCount;
    [SerializeField] private float _spacing;
    [SerializeField] private float _despawnDistance;
    private ObjectPool<Block> _pool = new ObjectPool<Block>();
    private List<Block> _instantiated = new List<Block>();

    private bool inited = false;

    private async void Start()
    {
        ObjectsData data = await Addressables.LoadAssetAsync<ObjectsData>(_factory).Task;
        
        foreach(Block go in data.Prefabs)
        {
            for(int i = 0; i < _pooledCount; i++)
            {
                Block obj = Instantiate(data.Prefabs[Random.Range(0, data.Prefabs.Length)], transform);
                obj.gameObject.SetActive(false);
                _pool.Put(obj);
            }
        }

        Addressables.Release(data);

        for(int i = 0; i < _instanceCount; i++)
        {
            Spawn();
        }

        inited = true;
    }

    private void Update()
    {
        if (!inited) return;

        if(Mathf.Abs(_car.transform.position.z - _instantiated[0].transform.position.z) > _despawnDistance)
        {
            Despawn();
            Spawn();
        }
    }

    private void Spawn()
    {
        if (!_pool.HaveObjects) return;

        Block go = _pool.GetRandom();

        if(_instantiated.Count != 0)
        {
            Block lastBlock = _instantiated[_instantiated.Count - 1];
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

    private void Despawn()
    {
        Block go = _instantiated[0];
        _instantiated.Remove(go);
        _pool.Put(go);
        go.gameObject.SetActive(false);
    }
}
