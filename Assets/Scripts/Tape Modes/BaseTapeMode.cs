using UnityEngine;

public abstract class BaseTapeMode : MonoBehaviour
{
    public string Name = "Generic Tape";
    public int Length = 30;
    public bool IsBusy { get; private set; } = false;
    
    [SerializeField] protected BaseWorldTape tapePrefab;

    public abstract void Shoot(Vector2 mousePosWp);
    public virtual void OnModePick() { }
    public virtual void OnModeLeave() { }
}
