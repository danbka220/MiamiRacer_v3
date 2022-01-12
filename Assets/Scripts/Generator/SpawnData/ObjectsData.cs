using UnityEngine;
using System.Collections.Generic;

public abstract class ObjectsData : ScriptableObject
{
    public abstract List<BlockBase> AllBlocks { get; }
}
