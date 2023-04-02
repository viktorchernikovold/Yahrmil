using UnityEngine;

public class uGUI_PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject content;
    public void Unpause()
    {
        GameManager.Unpause();
        content.SetActive(false);
    }
    public void Restart()
    {
        // reload current level
    }
    public void Exit()
    {
        // load main menu
    }

    private void Update()
    {
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Paused = !GameManager.Paused;
                content.SetActive(GameManager.Paused);
            }
        }
    }
}
