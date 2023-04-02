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
        Application.Quit();
    }
    private void Start()
    {
        MusicManager.SetBiome(Biome.Default);
    }
}
