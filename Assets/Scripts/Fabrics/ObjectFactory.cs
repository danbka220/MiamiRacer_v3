using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class ObjectFactory : ScriptableObject
{
    protected T CreateInstance<T>(T prefab) where T : MonoBehaviour
    {
        T go = Instantiate(prefab);
        
        return go;
    }
}
