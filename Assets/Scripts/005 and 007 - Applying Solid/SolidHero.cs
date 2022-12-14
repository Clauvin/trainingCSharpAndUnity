using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidHero: InterfaceHero
{
    SolidXP solidXP;
    SolidHP solidHP;
    SolidDamage solidDamage;
    
    public SolidHero()
    {
        solidXP = new SolidXP();
        solidHP = new SolidHP();
        solidDamage = new SolidDamage();
    }

    public SolidHero(int dice, int face)
    {
        solidXP = new SolidXP();
        solidHP = new SolidHP();
        solidDamage = new SolidDamage(dice, face);
    }

    public SolidHero(int HP, int dice, int face)
    {
        solidXP = new SolidXP();
        solidHP = new SolidHP(HP);
        solidDamage = new SolidDamage(dice, face);
    }

    public SolidHero(int[] dices, int[] faces)
    {
        solidXP = new SolidXP();
        solidHP = new SolidHP();
        solidDamage = new SolidDamage(dices, faces);
    }

    public SolidHero(int HP, int[] dices, int[] faces)
    {
        solidXP = new SolidXP();
        solidHP = new SolidHP(HP);
        solidDamage = new SolidDamage(dices, faces);
    }

    public InterfaceXP GetSolidXP()
    {
        return solidXP;
    }

    public InterfaceHP GetSolidHP()
    {
        return solidHP;
    }

    public InterfaceDamage GetSolidDamage()
    {
        return solidDamage;
    }
}
