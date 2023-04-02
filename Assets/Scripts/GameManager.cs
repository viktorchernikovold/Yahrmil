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


    public static void Pause() => Paused = true;
    public static void Unpause() => Paused = false;

    private void Awake()
    {
        main = this;
    }


    private static bool _paused = false;
    private static GameManager main;
}
