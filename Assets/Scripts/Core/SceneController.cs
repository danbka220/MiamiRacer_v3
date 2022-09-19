using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneFade _sceneFade;

    private Scene _currentScene;

    public enum Scenes
    {
        Persistent,
        Loading,
        Menu,
        Reforged
    }

    private void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            LoadScene(Scenes.Menu);
        }
    }

    public async void LoadScene(Scenes scene)
    {
        if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1).name != Scenes.Persistent.ToString())
            await _sceneFade.FadeIn();

        AsyncOperation operation = SceneManager.LoadSceneAsync(Scenes.Loading.ToString(), LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (_currentScene.IsValid())
            SceneManager.UnloadSceneAsync(_currentScene);

        operation = SceneManager.LoadSceneAsync(scene.ToString(),LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            await Task.Yield();
        }
        _currentScene = SceneManager.GetSceneByName(scene.ToString());

        operation = SceneManager.UnloadSceneAsync(Scenes.Loading.ToString());
        while (!operation.isDone)
        {
            await Task.Yield();
        }

        await _sceneFade.FadeOut();
    }
}
