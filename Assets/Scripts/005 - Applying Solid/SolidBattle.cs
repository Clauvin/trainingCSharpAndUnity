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

    public void AddHeroToTeamOne(InterfaceHero hero)
    {
        teamOne.Add(hero);
    }

    public void AddHeroToTeamTwo(InterfaceHero hero)
    {
        teamTwo.Add(hero);
    }

    public void DoBattleBetweenTeamsOneAndTwo()
    {
        if ((teamOne.Count == 0) && (teamTwo.Count == 0))
        {
            Debug.Log("Draw - both teams have no characters!");
        }
        else
        {
            if (teamOne.Count == 0)
            {
                Debug.Log("Team two wins... by default.");
            }
            else if (teamTwo.Count == 0)
            {
                Debug.Log("Team one wins... by default.");
            }
        }

        do
        {
            //Yeah, I know, it won't work with teams of more than one.
            int damageApplied = teamOne[0].GetSolidDamage().RollDamage();

            teamTwo[0].GetSolidHP().TakeDamage(damageApplied);

            if (IsTeamTwoStillStanding())
            {
                damageApplied = teamTwo[0].GetSolidDamage().RollDamage();

                teamOne[0].GetSolidHP().TakeDamage(damageApplied);
            }
            else break;
        } 
        while (IsTeamOneStillStanding() && IsTeamTwoStillStanding());

        //teamOne members attack each one a random target of teamTwo, with printed effects
        //if teamTwo is alive, repeat for teamTwo
        //when one team is dead, declare the other one victorious

        if (IsTeamOneStillStanding() && !IsTeamTwoStillStanding())
        {
            Debug.Log("Team one wins!");
        }
        else
        {
            Debug.Log("Team two wins!");
        }
    }

    public bool IsTeamOneStillStanding()
    {
        if (teamOne.Count == 0) { return false; }
        else
        {
            for (int i = 0; i < teamOne.Count; i++)
            {
                if (!teamOne[i].GetSolidHP().IsDead())
                {
                    return true;
                }
            }
            return false;
        }
    }

    public bool IsTeamTwoStillStanding()
    {
        if (teamTwo.Count == 0) { return false; }
        else
        {
            for (int i = 0; i < teamTwo.Count; i++)
            {
                if (!teamTwo[i].GetSolidHP().IsDead())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
