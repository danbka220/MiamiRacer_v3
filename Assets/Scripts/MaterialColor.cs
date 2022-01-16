using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColor : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _color = new Color(0,0,0,1);
    private MaterialPropertyBlock _colorProperty;

    private void Awake()
    {
        _colorProperty = new MaterialPropertyBlock();
        ChangeColor();
    }

    private void OnValidate()
    {
        _colorProperty = new MaterialPropertyBlock();
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (!_renderer) return;
        _colorProperty.Clear();
        _colorProperty.SetColor("_MainColor", _color);
        _renderer.SetPropertyBlock(_colorProperty, 0);
    }
}
