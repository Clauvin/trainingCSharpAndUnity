using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Print numbers from 1 to 100.
/// If the number is divisible by 3, print fizz instead
/// If the number is divisible by 5, print buzz instead
/// If the number is divisible by both, print fizzbuzz
/// </summary>
public class FizzBuzzKata : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Print();
    }

    public void Print()
    {
        for (int i = 1; i <= 100; i++)  //O(100)
        {
            string valueToPrint = ""; //O(1)
            if (i % 3 == 0) valueToPrint += "fizz"; //O(1)
            if (i % 5 == 0) valueToPrint += "buzz"; //O(1)
            if (valueToPrint == "") valueToPrint += i.ToString(); //O(1)
            Debug.Log(valueToPrint); //O
        }
    }
}
