using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class PersistentSceneAutoLoader
{
    private const string PERSISTENT_SCENE_PATH = "Assets/Scenes/Persistent.unity";
    private const string PREV_SCENE_PATH_KEY = "PREVIOUS_SCENE";

    static PersistentSceneAutoLoader()
    {
        EditorApplication.playModeStateChanged += OnPlay;
    }

    private static void OnPlay(PlayModeStateChange state)
    {
        if(!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            if (SceneManager.GetActiveScene().name == SceneController.Scenes.Persistent.ToString())
            {
                EditorPrefs.SetString(PREV_SCENE_PATH_KEY, SceneManager.GetActiveScene().path);
                return;
            }
                
            var path = SceneManager.GetActiveScene().path;
            EditorPrefs.SetString(PREV_SCENE_PATH_KEY, path);

            if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                try
                {
                    EditorSceneManager.OpenScene(PERSISTENT_SCENE_PATH);
                    EditorSceneManager.OpenScene(path,OpenSceneMode.Additive);
                }
                catch
                {
                    Debug.LogError($"Cannot load scene: {PERSISTENT_SCENE_PATH}");
                    EditorApplication.isPlaying = false;
                }
            }
            else
            {
                EditorApplication.isPlaying = false;
            }
        }

        if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            var path = EditorPrefs.GetString(PREV_SCENE_PATH_KEY);
            try
            {
                EditorSceneManager.OpenScene(path);
            }
            catch
            {
                Debug.LogError($"Cannot load scene: {path}");
            }
        }
    }
}
