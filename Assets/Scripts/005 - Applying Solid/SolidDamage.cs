using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidDamage : InterfaceDamage
{
    public List<int> amountOfDices;
    public List<int> amountOfFaces;

    public SolidDamage()
    {
        amountOfDices = new List<int>();
        amountOfDices.Add(1);

        amountOfFaces = new List<int>();
        amountOfFaces.Add(1);
    }

    public SolidDamage(int dice, int face)
    {
        amountOfDices = new List<int>();
        amountOfDices.Add(dice);

        amountOfFaces = new List<int>();
        amountOfFaces.Add(face);
    }

    public SolidDamage(int[] dices, int[] faces)
    {
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
