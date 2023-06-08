using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static MarsScriptingKata;

public class MarsScriptingTests
{
    public Vector2Int[] marsObstacles;
    public MarsLimits marsLimits;
    public MarsRoverData marsRoverData;


    [SetUp]
    public void SetUp()
    {
        marsObstacles = new Vector2Int[] { new Vector2Int(2, 2), new Vector2Int(2, 3) };
        marsLimits = new MarsLimits(1, 4, 1, 4, marsObstacles);
        marsRoverData = new MarsRoverData(1, 1, MarsScriptingKata.Direction.North, marsLimits);
    }

    [Test]
    public void MarsScriptingTestInitialization()
    {
        Assert.IsTrue(marsRoverData != null);
    }
    
    [Test]
    public void MarsScriptingTestGetCommandArray()
    {
        string testArray = "pfgijqg9qpefgui";

        marsRoverData.setCommandArray(testArray);

        Assert.IsTrue(marsRoverData.getCommandArray() == testArray);
    }

    [Test]
    public void MarsScriptingTestMoveForward()
    {
        string testArray = "ffff";

        marsRoverData.setCommandArray(testArray);
        marsRoverData.executeCommandArray();

        Assert.IsTrue(marsRoverData.getY() == 1);
    }

    [Test]
    public void MarsScriptingTestMoveBackward()
    {
        string testArray = "bbb";

        marsRoverData.setCommandArray(testArray);
        marsRoverData.executeCommandArray();

        Assert.IsTrue(marsRoverData.getY() == 2);
    }

    [Test]
    public void MarsScriptingTestTurnLeft()
    {
        string testArray = "lf";

        marsRoverData.setCommandArray(testArray);
        marsRoverData.executeCommandArray();

        Assert.IsTrue(marsRoverData.getX() == 4);
    }
    
    [Test]
    public void MarsScriptingTestTurnRight()
    {
        string testArray = "rf";

        marsRoverData.setCommandArray(testArray);
        marsRoverData.executeCommandArray();

        Assert.IsTrue(marsRoverData.getX() == 2);
    }

    [Test]
    public void MarsScriptiongTestStopOnObstacle()
    {
        string testArray = "frff";

        marsRoverData.setCommandArray(testArray);
        UnityEngine.TestTools.LogAssert.Expect(LogType.Error, "(2, 2)");
        Assert.IsTrue(marsRoverData.executeCommandArray() == new Vector2Int(2,2));
        
        
    }

}
