using UnityEngine;

public class uGUI_Popup : MonoBehaviour
{
    public GameObject Content;
    public void Show()
    {
        Content.SetActive(true);
    }
    public void Hide()
    {
        Content.SetActive(false);
    }
}
