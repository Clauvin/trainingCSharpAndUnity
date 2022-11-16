using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidBattle : InterfaceBattle
{
    List<InterfaceHero> teamOne;
    List<InterfaceHero> teamTwo;

    public SolidBattle()
    {
        teamOne = new List<InterfaceHero>();
        teamTwo = new List<InterfaceHero>();
    }

    public SolidBattle(InterfaceHero first, InterfaceHero second)
    {
        teamOne = new List<InterfaceHero>();
        teamTwo = new List<InterfaceHero>();

        teamOne.Add(first);
        teamTwo.Add(second);
    }

    public SolidBattle(List<InterfaceHero> teamOne, List<InterfaceHero> teamTwo)
    {
        this.teamOne = teamOne;
        this.teamTwo = teamTwo;
    }

    void InterfaceBattle.AddHeroToTeamOne(InterfaceHero hero)
    {
        throw new System.NotImplementedException();
    }

    void InterfaceBattle.AddHeroToTeamTwo(InterfaceHero hero)
    {
        throw new System.NotImplementedException();
    }

    void InterfaceBattle.DoBattleBetweenTeamsOneAndTwo()
    {
        throw new System.NotImplementedException();
    }
}
