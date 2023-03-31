using UnityEngine;

public abstract class PlayerModule : MonoBehaviour
{
    public Player Player { get; private set; }
    public bool Initialized { get; private set; }

    public void Init(Player player)
    {
        if (Initialized)
        {
            return;
        }
        Initialized = true;
        Player = player;
        OnInit();
    }

    #region Callbacks
    public virtual void OnInit() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
    public virtual void OnLateUpdate() { }
    #endregion
}
