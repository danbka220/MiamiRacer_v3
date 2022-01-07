using UnityEngine;
using UnityEditor;

public class CustomLitTransparentGUI : ShaderGUI
{
    MaterialProperty _mainTex;
    MaterialProperty _mainColor;
    MaterialProperty _emissionMap;
    MaterialProperty _emissionIntensity;
    MaterialProperty _specularColor;
    MaterialProperty _smoothnessMap;
    MaterialProperty _smoothnessIntensity;

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        _mainTex = ShaderGUI.FindProperty("_MainTex", properties);
        _mainColor = ShaderGUI.FindProperty("_MainColor", properties);
        _emissionMap = ShaderGUI.FindProperty("_EmissionMap", properties);
        _emissionIntensity = ShaderGUI.FindProperty("_EmissionIntensity", properties);
        _specularColor = ShaderGUI.FindProperty("_SpecularColor", properties);
        _smoothnessMap = ShaderGUI.FindProperty("_SmoothnessMap", properties);
        _smoothnessIntensity = ShaderGUI.FindProperty("_SmoothnessIntensity", properties);

        materialEditor.ShaderProperty(_mainTex, _mainTex.displayName);
        materialEditor.ShaderProperty(_mainColor, _mainColor.displayName);
        EditorGUILayout.Space(10f);
        materialEditor.ShaderProperty(_emissionMap, _emissionMap.displayName);
        materialEditor.ShaderProperty(_emissionIntensity, _emissionIntensity.displayName);
        EditorGUILayout.Space(10f);
        materialEditor.ShaderProperty(_specularColor, _specularColor.displayName);
        materialEditor.ShaderProperty(_smoothnessMap, _smoothnessMap.displayName);
        materialEditor.ShaderProperty(_smoothnessIntensity, _smoothnessIntensity.displayName);
    }
}
