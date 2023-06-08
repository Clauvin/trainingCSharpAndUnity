using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://kata-log.rocks/manhattan-distance-kata
//No obstacles
public class ManhattanDistanceKata : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(manhattanDistance(new Vector2Int(2, 2), new Vector2Int(10, 0)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int manhattanDistance(Vector2Int start, Vector2Int end)
    {
        //return positive(end[0] - start[0]) + positive (end[1] - start[1]);
        return Mathf.Abs(end[0] - start[0]) + Mathf.Abs(end[1] - start[1]);
    }
}
