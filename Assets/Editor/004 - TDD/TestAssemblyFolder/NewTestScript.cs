using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class BlockPlacerTests
{
    [OneTimeSetUp]
    public void NewTestSetUp()
    {
        SceneManager.LoadScene("EventsScene");
    }

    // A Test behaves as an ordinary method
    [Test, ConditionalIgnore("a", "Ignored.")]
    public void NewTestScriptSimplePasses()
    {
        Assert.AreEqual(true, true);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        var go = GameObject.Find("Teste");

        yield return new WaitForFixedUpdate();

        Assert.AreNotEqual(null, go);
    }
}
