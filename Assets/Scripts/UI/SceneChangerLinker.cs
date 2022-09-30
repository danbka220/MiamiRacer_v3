using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangerLinker : MonoBehaviour
{
    [SerializeField] private SceneController.Scenes _scene;

    private SceneController _sceneController;
    private Button _button;

    private void Awake()
    {
        _sceneController = FindObjectOfType<SceneController>();

        TryGetComponent<Button>(out _button);
    }

    private void OnEnable()
    {
        if (_button)
            _button.onClick.AddListener(ChangeScene);
    }

    private void OnDisable()
    {
        if (_button)
            _button.onClick.RemoveListener(ChangeScene);
    }

    public void ChangeScene()
    {
        ChangeScene(_scene);
    }

    private void ChangeScene(SceneController.Scenes scene)
    {
        if (!_sceneController)
            return;

        _sceneController.LoadScene(scene);
    }
}
