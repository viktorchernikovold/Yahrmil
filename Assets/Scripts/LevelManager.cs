using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelController ActiveController;
    public static LevelDefinition ActiveLevel;
    public static LevelDefinition Firstlevel => main._firstLevel;

    public static Action OnPreload;
    public static Action OnLoaded;

    public static void OnFinish()
    {
        if (ActiveLevel.IsEnding)
        {
            GoMenu();
        }
        else
        {
            main.StartCoroutine(NextLevel());
        }
    }
    public static IEnumerator GoMenu()
    {
        if (ActiveLevel != null)
        {
            OnPreload?.Invoke();
            main.StartCoroutine(LoadUnloadScenes(ActiveLevel.SceneName, "Menu"));
            OnLoaded?.Invoke();
        }
        else
        {
            OnPreload?.Invoke();
            main.StartCoroutine(LoadScene("Menu"));
            OnLoaded?.Invoke();
        }
        yield return null;
    }
    public static IEnumerator GoFirstLevel()
    {
        OnPreload?.Invoke();
        yield return null;
        ActiveLevel = Firstlevel;
        main.StartCoroutine(LoadUnloadScenes("Menu", ActiveLevel.SceneName));
        yield return null;
        ActiveController = LevelController.Active;
        if (ActiveController != null)
        {
            ActiveController.OnFinish += OnFinish;
        }
    }
    public static IEnumerator NextLevel()
    {
        if (ActiveController != null)
        {
            ActiveController.OnFinish += OnFinish;
        }
        OnPreload?.Invoke();
        yield return null;
        main.StartCoroutine(LoadUnloadScenes(ActiveLevel.SceneName, ActiveLevel.NextLevel.SceneName));
        yield return null;
        ActiveLevel = ActiveLevel.NextLevel;
        ActiveController = LevelController.Active;
        if (ActiveController != null)
        {
            ActiveController.OnFinish += OnFinish;
        }
    }
    public static IEnumerator RestartLevel()
    {
        OnPreload?.Invoke();
        yield return null;
        main.StartCoroutine(LoadUnloadScenes(ActiveLevel.SceneName, ActiveLevel.SceneName));
        yield return null;
        OnLoaded?.Invoke();
    }
    private static IEnumerator LoadUnloadScenes(string previous, string next)
    {
        yield return null;
        AsyncOperation unload = SceneManager.UnloadSceneAsync(previous);
        while (!unload.isDone)
        {
            yield return null;
        }
        AsyncOperation load = SceneManager.LoadSceneAsync(next, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(next));
    }
    private static IEnumerator LoadScene(string scene)
    {
        Debug.Log("Load Scene");
        yield return null;
        AsyncOperation load = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
    }

    private void Awake()
    {
        main = this;
    }


    [SerializeField] LevelDefinition _firstLevel;
    static LevelManager main;
}
