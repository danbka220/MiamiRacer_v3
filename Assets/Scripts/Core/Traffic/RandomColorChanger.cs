using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorChanger : MonoBehaviour
{
    [SerializeField, ColorUsage(showAlpha:false)] private Color[] _colors;
    [SerializeField] private Renderer _renderer;

    private void OnEnable()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (_colors.Length == 0) return;

        _renderer.material.SetColor("_MainColor", _colors[Random.Range(0, _colors.Length)]);
    }
}
