using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static Scene _currentScene;

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

    public static async void LoadScene(Scenes scene)
    {
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
        
        SceneManager.UnloadSceneAsync(Scenes.Loading.ToString());
    }
}
