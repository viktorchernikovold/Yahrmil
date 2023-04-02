using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uGUI_HudVisibility : MonoBehaviour
{
    [SerializeField] GameObject Content;
    void FixedUpdate()
    {
        Content.SetActive(GameManager.Playing && !GameManager.Paused);
    }
}
