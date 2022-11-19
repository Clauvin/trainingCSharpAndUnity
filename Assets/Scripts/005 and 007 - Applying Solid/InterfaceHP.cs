using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceHP
{

    public int GetHP();

    public int GetMaxHP();

    public void HealDamage(int amount);

    public void TakeDamage(int amount);

    public bool IsDead();

    
}

///Change Log
///(Current Version) v1.2 - Added GetMaxHP() function
/// v1.1 - Added GetHP() function
///
