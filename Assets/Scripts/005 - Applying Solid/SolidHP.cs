using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidHP : InterfaceHP
{
    public int currentHP;
    public int maxHP;

    public SolidHP()
    {
        currentHP = maxHP = 1;
    }

    public SolidHP(int HP)
    {
        if (HP <= 0)
        {
            HP = 1;
        }

        currentHP = maxHP = HP;
    }

    public void HealDamage(int healAmount)
    {
        if (healAmount < 0) healAmount = 0;

        currentHP += healAmount;

        if (IsCurrentHPBiggerThanMaxHP())
        {
            currentHP = maxHP;
        }

    }

    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0) damageAmount = 0;

        currentHP -= damageAmount;
    }

    public bool IsDead()
    {
        return currentHP <= 0;
    }

    private bool IsCurrentHPBiggerThanMaxHP()
    {
        return currentHP > maxHP;
    }
}
