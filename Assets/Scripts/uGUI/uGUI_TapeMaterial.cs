using UnityEngine;
using UnityEngine.UI;

public class uGUI_TapeMaterial : MonoBehaviour
{
    public DuctTape DuctTapeRef;
    public Image Icon;
    public Text Text;
    public Color[] Colors = new Color[4];
    void Start()
    {
        Icon = GetComponentInChildren<Image>();
        Text = GetComponentInChildren<Text>();
        DuctTapeRef = Player.Main.DuctTape;
        DuctTapeRef.OnMaterialChange += UpdateIcon;
        UpdateIcon(DuctTapeRef.CurrentMaterial);
    }
    private void UpdateIcon(DuctTapeMaterial Material)
    {
        Icon.color = Colors[DuctTapeRef.GetMaterialIndex(Material)];
        Text.text = DuctTapeRef.ModeRef.Name + " Tape";
    }
}
