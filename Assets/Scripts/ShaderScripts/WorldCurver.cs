using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCurver : MonoBehaviour
{
    [SerializeField, Range(-1, 1f)] private float _curveX;
    [SerializeField, Range(-1f, 1f)] private float _curveY;

    void LateUpdate()
    {
        
        Shader.SetGlobalFloat(Shader.PropertyToID("_CurveX"), _curveX);
        Shader.SetGlobalFloat(Shader.PropertyToID("_CurveY"), _curveY);
    }

    private void OnValidate()
    {
        Shader.SetGlobalFloat(Shader.PropertyToID("_CurveX"), _curveX);
        Shader.SetGlobalFloat(Shader.PropertyToID("_CurveY"), _curveY);
    }
}
