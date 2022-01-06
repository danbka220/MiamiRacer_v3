using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Factory/BlockFactory", fileName = "new BlockFactory", order = 0)]
public class BlocksFactory : ObjectFactory
{
    [SerializeField] private List<AssetReference> _prefabs;
    public List<GameObject> Prefabs { get; private set; } = new List<GameObject>();

    public async Task Init()
    {
        await GetAll(Prefabs);
    }

    public GameObject GetRandom()
    {
        return Prefabs[Random.Range(0, Prefabs.Count)];
    }

    private async Task GetAll(List<GameObject> list)
    {
        foreach (AssetReference refer in _prefabs)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(refer);
            await handle.Task;
            list.Add(handle.Result);
        }
    }
}
