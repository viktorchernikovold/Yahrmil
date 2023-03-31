using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Main { get; private set; }
    public PlayerModule[] Modules { get; private set; }


    public T GetModule<T>() where T : PlayerModule
    {
        return (T)Modules.First(x => x is T);
    }

    private void InitSingleton()
    {
        if (Main == null)
        {
            Main = this;
        }
        else if (Main != this)
        {
            Destroy(this.gameObject);
        }
    }
    private void InitMods()
    {
        Modules = GetComponentsInChildren<PlayerModule>();
        foreach(PlayerModule m in Modules)
        {
            m.Init(this);
        }
    }

    #region Unity Callbacks
    private void Awake()
    {
        InitSingleton();
        InitMods();
    }
    private void Update()
    {
        foreach(PlayerModule m in Modules)
        {
            if (m.Initialized)
            {
                m.OnUpdate();
            }
        }
    }
    private void FixedUpdate()
    {
        foreach (PlayerModule m in Modules)
        {
            if (m.Initialized)
            {
                m.OnFixedUpdate();
            }
        }
    }
    private void LateUpdate()
    {
        foreach (PlayerModule m in Modules)
        {
            if (m.Initialized)
            {
                m.OnLateUpdate();
            }
        }
    }
    #endregion
}
