using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidXP : InterfaceXP
{
    public float currentXP;

    public SolidXP()
    {
        currentXP = 0.0f;
    }

    public SolidXP(float XP)
    {
        currentXP = XP;
    }

    public float GainXP(float XP, float XP_multiplier)
    {
        if (XP < 0.0f) return currentXP;
        if (XP_multiplier < 0.0f) XP_multiplier = 0.0f;

        currentXP += XP * XP_multiplier;
        return currentXP;
    }

    public float LoseXP(float XP, float XP_multiplier)
    {
        if (XP < 0.0f) return currentXP;
        if (XP_multiplier < 0.0f) XP_multiplier = 0.0f;

        currentXP -= XP * XP_multiplier;
        return currentXP;
    }

    public float ReturnCurrentXP()
    {
        return currentXP;
    }
}
