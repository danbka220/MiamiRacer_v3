using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Generator : MonoBehaviour
{
    [SerializeField] private AssetReference _blockFactory;
    private BlocksFactory _factory;
    private List<GameObject> _objects = new List<GameObject>();

    private async void Start()
    {
        var handle = Addressables.LoadAssetAsync<BlocksFactory>(_blockFactory);
        await handle.Task;
        _factory = Instantiate(handle.Result);
        await _factory.Init();
        Generate();
    }

    private void Generate()
    {
        Instantiate(_factory.GetRandom());
    }
}
