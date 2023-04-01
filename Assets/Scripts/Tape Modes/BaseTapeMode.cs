using UnityEngine;

public abstract class BaseTapeMode : MonoBehaviour
{
    public int Length = 30;
    public bool IsBusy { get; private set; } = false;
    
    [SerializeField] BaseWorldTape tapePrefab;

    public abstract void Shoot(Vector2 hitInfo);
}
