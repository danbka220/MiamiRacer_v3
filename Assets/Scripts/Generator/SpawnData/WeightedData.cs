using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawnData/Weighted", fileName = "weighted", order = 1)]
public class WeightedData : ObjectsData
{
    [SerializeField] private BlockData[] _blocksData;

    public BlockData[] BlocksData => _blocksData;
    public override List<BlockBase> AllBlocks => _allBlocks;

    private List<BlockBase> _allBlocks = new List<BlockBase>();

    private void FillList()
    {
        _allBlocks.Clear();
        if (_blocksData.Length == 0) return;
        foreach (BlockData data in _blocksData)
        {
            if (data.Prefab)
                _allBlocks.Add(data.Prefab);
        }
    }

    private void OnValidate()
    {
        FillList();
    }
}

[System.Serializable]
public struct BlockData
{
    [SerializeField] private BlockBase _prefab;
    [SerializeField] private float _chance;

    public BlockBase Prefab => _prefab;
    public float Chance => _chance;
}
