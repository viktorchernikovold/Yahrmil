using UnityEngine;
using UnityEngine.UI;

public class uGUI_TapeMaterial : MonoBehaviour
{
    public DuctTape DuctTapeRef;
    public Image Icon;
    public Text Title;
    public Text Length;
    public Color[] Colors = new Color[4];
    void Start()
    {
        DuctTapeRef = Player.Main.DuctTape;
        DuctTapeRef.OnMaterialChange += UpdateIcon;
        UpdateIcon(DuctTapeRef.CurrentMaterial);
    }
    private void UpdateIcon(DuctTapeMaterial Material)
    {
        Icon.color = Colors[DuctTapeRef.GetMaterialIndex(Material)];
        Title.text = string.Format("{0} Tape", DuctTapeRef.ModeRef.Name);
        Length.text = string.Format("{0} meters left", DuctTapeRef.ModeRef.Length);
    }
}
