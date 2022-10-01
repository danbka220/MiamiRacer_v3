using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorIniter : MonoBehaviour
{
    [SerializeField] private List<GameObject> _generators = new List<GameObject>();
    private async void Awake()
    {
        for (int i = 0; i < _generators.Count; i++)
        {
            IGenerator og = _generators[i].GetComponent<IGenerator>();
            await og.Init();
        }
    }
}
