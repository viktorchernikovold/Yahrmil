using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uGUI_MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

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
}
