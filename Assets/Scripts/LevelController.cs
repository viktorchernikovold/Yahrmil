using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Active;
    public LevelDefinition Definition => definition;
    public event Action OnFinish;

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
    public void Finish()
    {
        OnFinish?.Invoke();
    }
    private void Start()
    {
        SetupDuctTape();
        MusicManager.SetBiome(Definition.Biome);
    }
    private void Awake()
    {
        Active = this;
    }


    [SerializeField] LevelDefinition definition;
}
