using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelDefinition Definition => definition;


    public void SetupDuctTape()
    {
        DuctTape tape = Player.Main.DuctTape;
        tape.AllowedMaterials = Definition.AllowedMaterials;
        for (int i = 1; i < 4; i *= 2)
        {
            int j = tape.GetMaterialIndex((DuctTapeMaterial)i);
            tape.AllModes[j].Length = Definition.MaterialsAmount[j];
        }
    }

    private void Start()
    {
        SetupDuctTape();
    }


    [SerializeField] LevelDefinition definition;
}
