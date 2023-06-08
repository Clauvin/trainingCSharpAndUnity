using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: https://kata-log.rocks/bowling-game-kata
//In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. However no more than three balls can be rolled in tenth frame.
//  Assuming that on the tenth frame the use of strikes and spares is automatic...

public class BowlingScriptKata : MonoBehaviour
{
    private int[] game_pins;
    private int[] game_rolls;
    private int[] game_points;
    private int[] game_bonuses;
    
    private int which_frame;
    private int which_roll;

    private int spare_multiplier;
    private int strike_multiplier;

    // Start is called before the first frame update
    void Start()
    {
        which_frame = 0;
        which_roll = 0;

        spare_multiplier = 0;
        strike_multiplier = 0;

        game_pins = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        game_rolls = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        game_points = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        game_bonuses = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        fullOnePlayerGame();

        Debug.LogAssertion(score());
    }

    private void fullOnePlayerGame()
    {
        while (which_frame < 10)
        {
            int amount_of_remaining_pins = game_pins[which_frame];
            roll(Random.Range(0, amount_of_remaining_pins + 1));

            if (game_pins[which_frame] == 0)
            {
                //strike!
                if (which_roll == 0)
                {
                    strike_multiplier += 2;
                }

                which_frame += 1;
                which_roll = 0;
            }
            else if (which_roll == 0)
            {
                which_roll++;
                amount_of_remaining_pins = game_pins[which_frame];
                roll(Random.Range(0, amount_of_remaining_pins + 1));

                //spare!
                if (game_pins[which_frame] == 0)
                {
                    spare_multiplier += 1;
                }
                else if ((which_frame == 9) && ((strike_multiplier > 0) || (spare_multiplier > 0)))
                {
                    which_roll++;
                    amount_of_remaining_pins = game_pins[which_frame];
                    roll(Random.Range(0, amount_of_remaining_pins + 1));
                }

                which_frame += 1;
                which_roll = 0;
            }
        }
    }

    private void roll(int pins)
    {    
        int pins_knocked_down = pins;

        game_rolls[which_frame * 2 + which_roll] = pins_knocked_down;

        game_pins[which_frame] -= pins_knocked_down;
        game_points[which_frame] += pins_knocked_down;

        if (which_frame != 9)
        {
            if (spare_multiplier > 0)
            {
                game_bonuses[which_frame] += pins_knocked_down;
                spare_multiplier -= 1;
            }

            if (strike_multiplier > 0)
            {
                game_bonuses[which_frame] += pins_knocked_down;
                strike_multiplier -= 1;
            }
        }
        
    }

    private int score()
    {
        int full_score = 0;
        string pins = "Pins = ";
        string rolls = "Rolls = ";
        string points = "Points = ";
        string bonuses = "Bonuses = ";

        for (int i = 0; i < 10; i++)
        {
            full_score += game_points[i];
            full_score += game_bonuses[i];
            pins += " " + game_pins[i];
            points += " " + game_points[i];
            bonuses += " " + game_bonuses[i];
        }

        for (int i = 0; i < 21; i++)
        {
            rolls += " " + game_rolls[i];
            if (i % 2 == 1) rolls += " | ";
        }

        Debug.LogAssertion(pins);
        Debug.LogAssertion(rolls);
        Debug.LogAssertion(points);
        Debug.LogAssertion(bonuses);

        return full_score;
    }

}
