using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCurver : MonoBehaviour
{
    [SerializeField, Range(-.1f, .1f)] private float _curveX;
    [SerializeField, Range(-.05f, .05f)] private float _curveY;
    [SerializeField] private Material[] _materials;


    void LateUpdate()
    {
        foreach (Material mat in _materials)
        {
            mat.SetFloat(Shader.PropertyToID("_CurveX"), _curveX);
            mat.SetFloat(Shader.PropertyToID("_CurveY"), _curveY);
        }
    }

    private void OnValidate()
    {
        foreach (Material mat in _materials)
        {
            mat.SetFloat(Shader.PropertyToID("_CurveX"), _curveX);
            mat.SetFloat(Shader.PropertyToID("_CurveY"), _curveY);
        }
    }
}
