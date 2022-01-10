using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Factory", fileName = "factory", order = 51)]
public class ObjectsData : ScriptableObject
{
    [SerializeField] private BlockBase[] _prefabs;

    public BlockBase[] Prefabs => _prefabs;
}
