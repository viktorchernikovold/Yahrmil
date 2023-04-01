using System;
using UnityEngine;

public abstract class BaseTapeMode : MonoBehaviour
{
    public string Name = "Generic Tape";
    public int Length
    {
        get => _length;
        set
        {
            int o = _length;
            _length = value;
            OnLengthChange?.Invoke(o, _length);
        }
    }
    public float MaxDistance;
    public byte Progress { get; protected set; } = 0;
    public BaseWorldTape CurrentTape { get; protected set; }
    public bool IsBusy { get; protected set; } = false;

    public event Action<int, int> OnLengthChange;

    [SerializeField] protected BaseWorldTape tapePrefab;
    private int _length = 30;

    public abstract void Shoot(Vector2 mousePosWp);
    public virtual void Begin(Vector2 pos) { }
    public virtual void End(Vector2 pos) { }
    public virtual void Interrupt() { }
    public virtual void OnModePick() { }
    public virtual void OnModeLeave() { }
}
