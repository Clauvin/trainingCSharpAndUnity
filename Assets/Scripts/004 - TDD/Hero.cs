using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    float currentXP;
    List<int> amountOfDices;
    List<int> amountOfFaces;

    public float getCurrentXP() { return currentXP; }

    public Hero()
    {
        currentXP = 0.0f;

        amountOfDices = new List<int>();
        amountOfDices.Add(1);

        amountOfFaces = new List<int>();
        amountOfFaces.Add(1);
    }

    public Hero(int dice, int face)
    {
        currentXP = 0.0f;

        amountOfDices = new List<int>();
        amountOfDices.Add(dice);

        amountOfFaces = new List<int>();
        amountOfFaces.Add(face);
    }

    public Hero(int[] dices, int[] faces)
    {
        currentXP = 0.0f;

        amountOfDices = new List<int>();
        for (int i = 0; i < dices.Length; i++)
        {
            amountOfDices.Add(dices[i]);
        }
        

        amountOfFaces = new List<int>();
        for (int i = 0; i < faces.Length; i++)
        {
            amountOfFaces.Add(faces[i]);
        }
    }

    public float GainXP(float XP, float XP_multiplier)
    {
        if (XP < 0.0f) return currentXP;
        if (XP_multiplier < 0.0f) XP_multiplier = 0.0f;

        currentXP += XP * XP_multiplier;
        return currentXP;
    }

    public List<int> CalculateMinAndMaxDamage()
    {
        List<int> minAndMaxDamage = new List<int>();

        int minDamage = 0;
        int maxDamage = 0;

        for (int i = 0; i < amountOfDices.Count; i++)
        {
            minDamage += amountOfDices[i] * 1;
            maxDamage += amountOfDices[i] * amountOfFaces[i];
        }

        minAndMaxDamage.Add(minDamage);
        minAndMaxDamage.Add(maxDamage);

        return minAndMaxDamage;
    }
}
