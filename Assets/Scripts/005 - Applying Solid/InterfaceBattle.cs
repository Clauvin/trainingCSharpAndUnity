using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceBattle
{
    public void AddHeroToTeamOne(InterfaceHero hero);
    public void AddHeroToTeamTwo(InterfaceHero hero);

    public void DoBattleBetweenTeamsOneAndTwo();


}
