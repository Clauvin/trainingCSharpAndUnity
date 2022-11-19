using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceHP
{
    public void HealDamage(int amount);

    public void TakeDamage(int amount);

    public bool IsDead();


}
