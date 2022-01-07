using UnityEngine;
using UnityEditor;

public class CustomLitOpaqueGUI : ShaderGUI
{
    MaterialProperty _mainTex;
    MaterialProperty _colorMask;
    MaterialProperty _albedoColor;
    MaterialProperty _normalMap;
    MaterialProperty _normalOffset;
    MaterialProperty _normalStrength;
    MaterialProperty _metallicMap;
    MaterialProperty _metallicIntensity;
    MaterialProperty _smoothnessMap;
    MaterialProperty _smoothnessIntensity;
    MaterialProperty _emission;

    bool showPosition = false;

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        _mainTex = FindProperty("_MainTex", properties);
        _colorMask = ShaderGUI.FindProperty("_ColorMask", properties);
        _albedoColor = FindProperty("_MainColor", properties);
        _normalMap = FindProperty("_NormalMap", properties);
        _normalOffset = FindProperty("_NormalOffset", properties);
        _normalStrength = FindProperty("_NormalStrength", properties);
        _metallicMap = FindProperty("_MetallicMap", properties);
        _metallicIntensity = FindProperty("_MetallicIntensity", properties);
        _smoothnessMap = FindProperty("_SmoothnessMap", properties);
        _smoothnessIntensity = FindProperty("_SmoothnessIntensity", properties);

        materialEditor.ShaderProperty(_mainTex, _mainTex.displayName);
        materialEditor.ShaderProperty(_colorMask, _colorMask.displayName);
        materialEditor.ShaderProperty(_albedoColor, _albedoColor.displayName);
        EditorGUILayout.Space(8f);
        materialEditor.ShaderProperty(_normalMap, _normalMap.displayName);
        materialEditor.ShaderProperty(_normalOffset, _normalOffset.displayName);
        materialEditor.ShaderProperty(_normalStrength, _normalStrength.displayName);
        EditorGUILayout.Space(8f);
        materialEditor.ShaderProperty(_metallicMap, _metallicMap.displayName);
        materialEditor.ShaderProperty(_metallicIntensity, _metallicIntensity.displayName);
        EditorGUILayout.Space(8f);
        materialEditor.ShaderProperty(_smoothnessMap, _smoothnessMap.displayName);
        materialEditor.ShaderProperty(_smoothnessIntensity, _smoothnessIntensity.displayName);

        EditorGUILayout.Space(8f);
        _emission = FindProperty("_Emission", properties);
        materialEditor.ShaderProperty(_emission, _emission.displayName);

        MaterialProperty emissionMap = FindProperty("_EmissionMap", properties);
        MaterialProperty emissionStrength = FindProperty("_EmissionStrength", properties);
        materialEditor.ShaderProperty(emissionStrength, emissionStrength.displayName);
        materialEditor.ShaderProperty(emissionMap, emissionMap.displayName);

        EditorGUILayout.Space(8f);
        showPosition = EditorGUILayout.BeginFoldoutHeaderGroup(showPosition, "Curve setup");
        if (showPosition)
        {
            MaterialProperty curveY = FindProperty("_CurveY", properties);
            MaterialProperty curveX = FindProperty("_CurveX", properties);
            materialEditor.ShaderProperty(curveY, curveY.displayName);
            materialEditor.ShaderProperty(curveX, curveX.displayName);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
}
