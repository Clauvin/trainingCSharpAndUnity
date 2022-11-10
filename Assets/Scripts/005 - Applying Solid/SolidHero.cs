using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidHero
{
    SolidXP solidXP;
    SolidDamage solidDamage;
    
    public SolidHero()
    {
        solidXP = new SolidXP();
        solidDamage = new SolidDamage();
    }

    public SolidHero(int dice, int face)
    {
        solidXP = new SolidXP();
        solidDamage = new SolidDamage(dice, face);
    }

    public SolidHero(int[] dices, int[] faces)
    {
        solidXP = new SolidXP();
        solidDamage = new SolidDamage(dices, faces);
    }

    public SolidXP GetSolidXP()
    {
        return solidXP;
    }

    public SolidDamage GetSolidDamage()
    {
        return solidDamage;
    }
}
