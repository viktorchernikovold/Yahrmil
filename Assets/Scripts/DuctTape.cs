using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctTape : MonoBehaviour
{
    public DuctTapeMode Mode { get; private set; } = DuctTapeMode.Bounce;
    public DuctTapeMode AvailableModes = DuctTapeMode.Bounce;

    public void Use(){

    }
    public void AltUse(){
        if (((byte)AvailableModes) == 0){
            return;
        }
        while ((Mode & AvailableModes) == 0){
            byte n = (byte)Mode;
            n *= 2;
            if (n > 8){
                n = 1;
            }
        }
    }
}
[Flags]
public enum DuctTapeMode : byte {
    Bounce = 1 << 0,
    Speed = 1 << 1,
    Hook = 1 << 2,
    Path = 1 << 3,
}