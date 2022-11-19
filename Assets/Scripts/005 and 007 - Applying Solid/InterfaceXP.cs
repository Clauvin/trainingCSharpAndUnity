using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceXP
{
    public float GainXP(float XP, float XP_multiplier);

    public float LoseXP(float XP, float XP_multiplier);

    public float ReturnCurrentXP();
}
