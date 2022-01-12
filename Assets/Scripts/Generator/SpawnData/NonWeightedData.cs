using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpawnData/Non weighted", fileName = "weighted", order = 0)]
public class NonWeightedData : ObjectsData
{
    [SerializeField] private List<BlockBase> _prefabs = new List<BlockBase>();

    public override List<BlockBase> AllBlocks => _prefabs;
}
