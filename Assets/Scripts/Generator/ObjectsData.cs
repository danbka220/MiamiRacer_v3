using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Factory", fileName = "factory", order = 51)]
public class ObjectsData : ScriptableObject
{
    [SerializeField] private Block[] _prefabs;

    public Block[] Prefabs => _prefabs;
}
