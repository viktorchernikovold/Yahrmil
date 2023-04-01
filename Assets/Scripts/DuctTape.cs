using System;
using UnityEngine;

public class DuctTape : MonoBehaviour
{
    /// <summary>
    /// Gets total lenght of the duct tape.
    /// </summary>
    public int TotalLength
    {
        get 
        {
            int l = 0;
            foreach(BaseTapeMode m in modes) l += m.Length;
            return l;
        }
    }
    /// <summary>
    /// Tells if duct tape is available for use.
    /// </summary>
    public bool Available => ModeRef.IsBusy;
    /// <summary>
    /// Gets active duct tape mode.
    /// </summary>
    public DuctTapeMode ActiveMode /*{ get; private set; }*/ = DuctTapeMode.Bounce;
    /// <summary>
    /// Available modules for use.
    /// </summary>
    public DuctTapeMode AvailableModes = DuctTapeMode.Bounce;
    /// <summary>
    /// Gets a reference to the active module.
    /// </summary>
    public BaseTapeMode ModeRef /*{ get; private set; }*/ = null;

    [SerializeField] Transform shootOrigin;
    BaseTapeMode[] modes;

    
    public void Use(){
        if (Available)
        {
            ModeRef.Shoot(Vector2.zero);
        }
    }
    public void AltUse(){
        if (((byte)AvailableModes) == 0 || Available){
            return;
        }
        do
        {
            byte n = (byte)ActiveMode;
            n *= 2;
            if (n > 8)
            {
                n = 1;
            }
            ActiveMode = (DuctTapeMode)n;
        }
        while ((ActiveMode & AvailableModes) == 0);
        ModeRef = ModeToRef(ActiveMode);
    }
    #region Helpers
    private BaseTapeMode ModeToRef(DuctTapeMode mode)
    {
        return modes[Mathf.RoundToInt(Mathf.Log((byte)mode, 2))];
    }
    #endregion

    #region Unity callbacks
    private void Awake()
    {
        modes = GetComponentsInChildren<BaseTapeMode>();
        ModeRef = ModeToRef(ActiveMode);
    }
    /* 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Use();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            AltUse();
        }
    }
    */
    #endregion
}
[Flags]
public enum DuctTapeMode : byte {
    Bounce = 1 << 0,
    Speed = 1 << 1,
    Hook = 1 << 2,
    Path = 1 << 3,
}