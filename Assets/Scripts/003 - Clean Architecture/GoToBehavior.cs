using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBehavior : MonoBehaviour
{
    void LetsGoto()
    {
        int numberOfHey = 0;
        Hey:
            numberOfHey += 1;
            Debug.Log("Oi :D");

        if (numberOfHey < 5)
        {
            goto Hey;
        }

        return;
    }

    void LetsGoto2()
    {

        int a = 2;
        switch (a)
        {
            case 2:
                Debug.Log("2");
                goto case 3;

            case 3:
                Debug.Log("3");
                break;
        }

        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        LetsGoto();
        LetsGoto2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
