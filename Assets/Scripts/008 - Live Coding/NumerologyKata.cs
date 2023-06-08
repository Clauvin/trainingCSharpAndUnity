using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://github.com/Gianfrancoalongi/incremental_katas/blob/master/Numerology/kata.txt
/// https://github.com/Gianfrancoalongi/incremental_katas/blob/master/Numerology/step_02.txt
/// 
/// replacing all 2's
/// by an equal amount of ones as the number to the left of the 2, and all 6's by
/// an equal amount of 3's as the value of the number which is an equal amount of
/// steps to the right of the 6 as the number which is to the immediate left of it.
/// 
/// https://github.com/Gianfrancoalongi/incremental_katas/blob/master/Numerology/step_03.txt
/// 
/// For the next task, you will extend the functionality by adding the ability to 
/// replace any 3 by a 5 if not immediately succeeded by 5 and any 4 by a 3 if not 
/// immediately preceeded by 5. When replacing the 3's and 4's, you may not replace
/// more than one 3 or 4 in a go without having replaced one instance of the other
/// in between. When four 3's have been replaced, and three 4's have been replaced.
/// No more replacements may occur until a 7 is seen. Once a 7 is seen, the whole
/// process is reset and four 3's and three 4's may be replaced again.
/// 
/// replace a 3 by a 5 if the three is not just to the left of a 5
/// replace a 4 by a 3 if the four is not just to the right of a 5 
/// if 4 3's and 3 4's are replaced = no more replacements until a 7 is seen.
/// 
/// </summary>
public class NumerologyKata : MonoBehaviour
{
    bool canReplaceThreesAndFours;
    int amountOfSeenThrees;
    int amountOfSeenFours;
    bool seenASeven;

    void Awake()
    {
        canReplaceThreesAndFours = true;
        amountOfSeenThrees = 0;
        amountOfSeenFours = 0;
        seenASeven = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] answer = NumberReplacer(new int[] { 1, 6, 3, 4, 5 });
        Debug.Log(string.Join("\n", answer));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int[] NumberReplacer(int[] numberArray)
    {
        
        

        List<int> numberReceiver = new List<int>(numberArray.Length * 9);

        /// replace a 3 by a 5 if the three is not just to the left of a 5
        /// replace a 4 by a 3 if the four is not just to the right of a 5 
        /// if 4 3's and 3 4's are replaced = no more replacements until a 7 is seen.

        for (int i = 0; i < numberArray.Length; i++)
        {

            switch (numberArray[i])
            {
                case 2:
                    int amountOfOnes = numberArray[i - 1];
                    for (int j = 0; j < amountOfOnes; j++)
                    {
                        numberReceiver.Add(1);
                    }
                    break;
                case 3:
                    if (canReplaceThreesAndFours)
                    {
                        if (numberArray[i + 1] != 5)
                        {
                            numberReceiver.Add(5);
                        }
                        else numberReceiver.Add(numberArray[i]);
                        amountOfSeenThrees += 1;
                        ThreeFoursAndFourThrees();
                    }
                    else numberReceiver.Add(numberArray[i]);

                    break;
                case 4:
                    if (canReplaceThreesAndFours)
                    {
                        if (numberArray[i - 1] != 5)
                        {
                            numberReceiver.Add(3);
                        }
                        else numberReceiver.Add(numberArray[i]);
                        amountOfSeenFours += 1;
                        ThreeFoursAndFourThrees();
                    }
                    else numberReceiver.Add(numberArray[i]);
                    break;
                case 6:
                    int distance = numberArray[i - 1];
                    int amountOfThrees = numberArray[i + distance];
                    for (int j = 0; j < amountOfThrees; j++)
                    {
                        numberReceiver.Add(3);
                    }
                    break;
                case 7:
                    SevenResets();
                    break;
                case 9:
                    numberReceiver.Add(10);
                    numberReceiver.Add(10);
                    break;
                default:
                    numberReceiver.Add(numberArray[i]);
                    break;
            }

        }

        return numberReceiver.ToArray();
    }

    void ThreeFoursAndFourThrees()
    {
        if ((amountOfSeenFours >= 3) && (amountOfSeenThrees >= 4))
        {
            canReplaceThreesAndFours = false;
        }
    }

    void SevenResets()
    {
        canReplaceThreesAndFours = true;
        amountOfSeenFours = 0;
        amountOfSeenThrees = 0;
    }

}
