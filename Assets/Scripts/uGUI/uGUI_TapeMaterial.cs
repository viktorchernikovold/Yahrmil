using UnityEngine;
using UnityEngine.UI;

public class uGUI_TapeMaterial : MonoBehaviour
{
    public DuctTape DuctTapeRef;
    public Image Icon;
    public Text Title;
    public Text Length;

    private void FixedUpdate()
    {
        if (Player.Main != null)
        {
            DuctTape d = Player.Main.DuctTape;
            Icon.color = d.ModeRef.GetColor();
            Title.text = string.Format("{0} Tape", d.ModeRef.Name);
            Length.text = string.Format("{0} meters left", d.ModeRef.Length);
        }
    }
}
