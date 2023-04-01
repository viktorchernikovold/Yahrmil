using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseWorldTape : MonoBehaviour
{
    public virtual void OnPlayerEnter(Player player) { }
    public virtual void OnPlayerStay(Player player) { }
    public virtual void OnPlayerExit(Player player) { }
}
