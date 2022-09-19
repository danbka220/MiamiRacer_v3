using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SceneFade : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField, Min(0)] private float _fadeTime;

    public async Task FadeIn()
    {
        float elapsedTime = 0;

        _fadeImage.gameObject.SetActive(true);

        while(elapsedTime < _fadeTime)
        {
            Color newColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, Mathf.Lerp(0, 1, elapsedTime / _fadeTime));
            _fadeImage.color = newColor;

            elapsedTime += Time.unscaledDeltaTime;

            await Task.Yield();
        }
    }

    public async Task FadeOut()
    {
        Time.timeScale = 0;
        _fadeImage.gameObject.SetActive(true);
        float elapsedTime = 0;

        while (elapsedTime < _fadeTime)
        {
            Color newColor = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, Mathf.Lerp(1, 0, elapsedTime / _fadeTime));
            _fadeImage.color = newColor;

            elapsedTime += Time.unscaledDeltaTime;

            await Task.Yield();
        }

        _fadeImage.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
