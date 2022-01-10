using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

public abstract class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private CarBase _car;
    [SerializeField] private AssetReferenceT<ObjectsData> _factory;
    [SerializeField] private int _instanceCount;
    [SerializeField] private int _pooledCount;
    [SerializeField] private float _despawnDistance;
    protected ObjectPool<BlockBase> _pool = new ObjectPool<BlockBase>();
    protected List<BlockBase> _instantiated = new List<BlockBase>();

    private bool inited = false;

    private async void Start()
    {
        ObjectsData data = await Addressables.LoadAssetAsync<ObjectsData>(_factory).Task;
        
        foreach(BlockBase go in data.Prefabs)
        {
            for(int i = 0; i < _pooledCount; i++)
            {
                BlockBase obj = Instantiate(data.Prefabs[Random.Range(0, data.Prefabs.Length)], transform);
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

    protected abstract void Spawn();

    protected abstract void Despawn();
}
