using UnityEngine;
using UnityEngine.UI;

public class uGUI_TapeMaterial : MonoBehaviour
{
    public DuctTape DuctTapeRef;
    public Image Icon;
    public Text Title;
    public Text Length;


    private void Start()
    {
        DuctTapeRef = Player.Main.DuctTape;
        DuctTapeRef.OnMaterialChange += UpdateIcon;
        DuctTapeRef.OnLengthChange += UpdateLength;
        UpdateIcon(DuctTapeRef.CurrentMaterial);
    }
    private void UpdateIcon(DuctTapeMaterial Material)
    {
        Icon.color = DuctTapeRef.ModeRef.GetColor();
        Title.text = string.Format("{0} Tape", DuctTapeRef.ModeRef.Name);
        UpdateLength(0, DuctTapeRef.ModeRef.Length);
    }
    private void UpdateLength(int oldLength, int newLength)
    {
        Length.text = string.Format("{0} meters left", DuctTapeRef.ModeRef.Length);
    }
}
