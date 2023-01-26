using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangerLinker : MonoBehaviour
{
    [SerializeField] private SceneController.Scenes _scene;

    private SceneController _sceneController;
    private Button _button;

    private void Start()
    {
        _sceneController = FindObjectOfType<SceneController>();

        TryGetComponent<Button>(out _button);

        if (_button)
            _button.onClick.AddListener(ChangeScene);
    }

    private void OnDestroy()
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

        _ = _sceneController.LoadScene(scene);
    }
}
