using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGBattleTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InterfaceHero hero_one = new SolidHero(50, 2, 6);
        InterfaceHero hero_two = new SolidHero(50, 2, 6);

        InterfaceBattle battle = new SolidBattle(hero_one, hero_two);

        battle.DoBattleBetweenTeamsOneAndTwo();
    }
}
