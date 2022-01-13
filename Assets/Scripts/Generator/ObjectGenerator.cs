using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

public abstract class ObjectGenerator<T> : MonoBehaviour where T : BlockBase
{
    [SerializeField] private CarBase _car;
    [SerializeField] private AssetReferenceT<ObjectsData> _factory;
    [SerializeField] private int _instanceCount;
    [SerializeField] private int _pooledCount;
    [SerializeField] private float _despawnDistance;
    protected abstract ObjectPool<T> Pool { get; }
    protected List<T> _instantiated = new List<T>();

    private bool inited = false;

    private async void Start()
    {
        ObjectsData data = await Addressables.LoadAssetAsync<ObjectsData>(_factory).Task;

        InitPool(data);

        Addressables.Release(data);

        for (int i = 0; i < _instanceCount; i++)
        {
            Spawn();
        }

        inited = true;
    }

    private void InitPool(ObjectsData data)
    {
        for (int prefabId = 0; prefabId < data.AllBlocks.Count; prefabId++)
        {
            BlockBase go = data.AllBlocks[prefabId];
            for (int i = 0; i < _pooledCount; i++)
            {
                if (data.AllBlocks[prefabId].GetType() != typeof(T)) throw new System.Exception(" ≈сть блок несоответствующий типу генератора");

                T obj = (T)Instantiate(data.AllBlocks[prefabId], transform);
                obj.gameObject.SetActive(false);
                if (data is WeightedData)
                    obj.SpawnChance = ((WeightedData)data).BlocksData[prefabId].Chance;
                Pool.Put(obj);
            }
        }
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

    protected void Despawn()
    {
        T go = _instantiated[0];
        _instantiated.Remove(go);
        Pool.Put(go);
        go.gameObject.SetActive(false);
    }
}
