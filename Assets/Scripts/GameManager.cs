using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Playing { get; private set; }
    public static bool Paused
    {
        get => _paused;
        set
        {
            if (value != _paused)
            {
                _paused = value;
                Time.timeScale = _paused ? 0 : 1;
                OnPause?.Invoke(_paused);
            }
        }
    }

    public static event Action<bool> OnPause;


    public static void BeginGame()
    {
        main.StartCoroutine(LevelManager.GoFirstLevel());
        Playing = true;
        Paused = false;
    }
    public static void EndGame()
    {
        main.StartCoroutine(LevelManager.GoMenu());
        Playing = false;
        Paused = false;
    }
    public static void Pause() => Paused = true;
    public static void Unpause() => Paused = false;

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        StartCoroutine(LevelManager.GoMenu());
    }


    private static bool _paused = false;
    private static GameManager main;
}
