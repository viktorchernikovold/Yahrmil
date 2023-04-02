using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uGUI_MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.BeginGame();
    }
    public void ShowCredits()
    {

    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit;
#endif
    }
    private void Start()
    {
        MusicManager.SetBiome(Biome.Default);
    }
}
