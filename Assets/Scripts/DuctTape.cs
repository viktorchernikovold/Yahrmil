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
    public bool Available => !ModeRef.IsBusy;
    /// <summary>
    /// Gets active duct tape material.
    /// </summary>
    public DuctTapeMaterial CurrentMaterial /*{ get; private set; }*/ = DuctTapeMaterial.Bounce;
    /// <summary>
    /// Available materials for use.
    /// </summary>
    public DuctTapeMaterial AllowedMaterials = DuctTapeMaterial.Bounce;
    /// <summary>
    /// Gets a reference to the active module.
    /// </summary>
    public BaseTapeMode ModeRef /*{ get; private set; }*/ = null;

    public event Action<DuctTapeMaterial> OnMaterialChange;

    [SerializeField] Transform shootOrigin;
    BaseTapeMode[] modes;

    
    public void Use(){
        if (Available)
        {
            Vector2 mp = Input.mousePosition;
            mp = Camera.main.ScreenToWorldPoint(mp);
            ModeRef.Shoot(mp);
        }
    }
    public void AltUse(){
        BaseTapeMode oldMode = ModeRef;
        if (((byte)AllowedMaterials) == 0 || !Available){
            return;
        }
        do
        {
            byte n = (byte)CurrentMaterial;
            n *= 2;
            if (n > 8)
            {
                n = 1;
            }
            CurrentMaterial = (DuctTapeMaterial)n;
        }
        while ((CurrentMaterial & AllowedMaterials) == 0);
        ModeRef = modes[GetMaterialIndex(CurrentMaterial)];
        if (oldMode != ModeRef)
        {
            oldMode.OnModeLeave();
            OnMaterialChange?.Invoke(CurrentMaterial);
            ModeRef.OnModePick();
        }
    }
    #region Helpers
    public int GetMaterialIndex(DuctTapeMaterial mode)
    {
        return Mathf.RoundToInt(Mathf.Log((byte)mode, 2));
    }
    #endregion

    #region Unity callbacks
    private void Awake()
    {
        modes = GetComponentsInChildren<BaseTapeMode>();
        ModeRef = modes[GetMaterialIndex(CurrentMaterial)];
        ModeRef.OnModePick();
        OnMaterialChange?.Invoke(CurrentMaterial);
    }
    
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
    
    #endregion
}
[Flags]
public enum DuctTapeMaterial : byte {
    Bounce = 1 << 0,
    Speed = 1 << 1,
    Hook = 1 << 2,
    Path = 1 << 3,
}