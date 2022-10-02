using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneFade _sceneFade;

    private Scene _currentScene;
    private ActionsHandler _actions;

    public enum Scenes
    {
        Persistent,
        Loading,
        Menu,
        Reforged
    }

    private async void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            await LoadScene(Scenes.Menu);
            return;
        }

        _currentScene = SceneManager.GetActiveScene();
        _actions = FindObjectOfType<ActionsHandler>();
    }

    public async Task LoadScene(Scenes scene)
    {
        _actions.LockActions();
        _actions.FreezeTime();

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

        SceneManager.SetActiveScene(_currentScene);

        operation = SceneManager.UnloadSceneAsync(Scenes.Loading.ToString());
        while (!operation.isDone)
        {
            await Task.Yield();
        }

        await _sceneFade.FadeOut();

        _actions.UnlockActions();
        _actions.UnfreezeTime();
    }
}
