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

    public async void LoadScene(Scenes scene)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene.ToString(),LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(Scenes.Loading.ToString());

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        SceneManager.UnloadSceneAsync(_currentScene);
        SceneManager.UnloadSceneAsync(Scenes.Loading.ToString());
    }
}
