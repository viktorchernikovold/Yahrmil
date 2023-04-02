using UnityEngine;

[CreateAssetMenu(fileName = "Level Definition", menuName = "Definitions/LevelDefinition")]
public class LevelDefinition : ScriptableObject
{
    public string SceneName => _sceneName;
    public DuctTapeMaterial AllowedMaterials => _allowedMaterials;
    public int[] MaterialsAmount => _materialsAmount;
    public bool Cinematic => _cinematic;
    public bool IsBeginning => _previousLevel == null;
    public bool IsEnding => _nextLevel == null;
    public LevelDefinition NextLevel => _nextLevel;
    public LevelDefinition PreviousLevel => _previousLevel;

    [Header("Settings")]
    [SerializeField] string _sceneName;
    [SerializeField] DuctTapeMaterial _allowedMaterials;
    [SerializeField] int[] _materialsAmount = new int[4];
    [SerializeField] bool _cinematic;
    [Header("Linked levels")]
    [SerializeField] LevelDefinition _nextLevel;
    [SerializeField] LevelDefinition _previousLevel;
}
