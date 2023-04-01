using UnityEngine;

public abstract class BaseTapeMode : MonoBehaviour
{
    public string Name = "Generic Tape";
    public int Length = 30;
    public float MaxDistance;
    public byte Progress { get; protected set; } = 0;
    public BaseWorldTape CurrentTape { get; protected set; }
    public bool IsBusy { get; protected set; } = false;
    
    [SerializeField] protected BaseWorldTape tapePrefab;

    public abstract void Shoot(Vector2 mousePosWp);
    public virtual void Begin(Vector2 pos) { }
    public virtual void End(Vector2 pos) { }
    public virtual void Interrupt() { }
    public virtual void OnModePick() { }
    public virtual void OnModeLeave() { }
}
