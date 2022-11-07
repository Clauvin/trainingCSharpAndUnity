using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
[Author("Cláuvin Almeida", "almeidaclauvin@gmail.com")]
public class IdleSystemTests
{
    private int amountOfTests;

    [OneTimeSetUp]
    public void Init()
    {
        amountOfTests = 0;
    }

    [OneTimeTearDown]
    public void Cleanup()
    {
        Debug.Log(":)");
    }

    #region GainXPTests
    [Test, Description("Bla bla bla 2")]
    [TestCase(1.0f, 1.0f)]
    [TestCase(10.0f, 2.0f)]
    public void GainXP_Tests_PositiveValues(float exp_gained, float exp_multiplier)
    {
        if (exp_gained < 0.0f)
        {
            throw new ArgumentOutOfRangeException("exp_gained should be positive");
        }

        if (exp_multiplier < 0.0f)
        {
            throw new ArgumentOutOfRangeException("exp_multiplier should be positive");
        }

        var XP = new Hero().getCurrentXP();

        var hero = new Hero();
        hero.GainXP(exp_gained, exp_multiplier);

        Assert.AreEqual(XP + exp_gained * exp_multiplier, hero.getCurrentXP());
    }

    [TestCase(-1.0f, 1.0f)]
    [TestCase(-10.0f, 10.0f)]
    [TestCase(-10.0f, -10.0f)]
    public void GainXP_NegativeXPEdgeCase(float exp_gained, float exp_multiplier)
    {
        if (exp_gained > 0.0f)
        {
            throw new ArgumentOutOfRangeException("exp_gained should be negative");
        }

        var XP = new Hero().getCurrentXP();

        var hero = new Hero();
        hero.GainXP(exp_gained, exp_multiplier);

        Assert.AreEqual(0.0f, hero.getCurrentXP());
    }

    [TestCase(1.0f, -1.0f)]
    [TestCase(10.0f, -10.0f)]
    [TestCase(-10.0f, -10.0f)]
    public void GainXP_NegativeXPMultiplerEdgeCase(float exp_gained, float exp_multiplier)
    {
        if (exp_multiplier > 0.0f)
        {
            throw new ArgumentOutOfRangeException("exp_multiplier should be negative");
        }

        var XP = new Hero().getCurrentXP();

        var hero = new Hero();
        hero.GainXP(exp_gained, exp_multiplier);

        Assert.AreEqual(XP + exp_gained * 0.0f, hero.getCurrentXP());
    }
    #endregion

    #region CombatSystemTests
    [Test, Description("Bla bla bla")]
    public void GetGenericMinAndMaxDamage()
    {
        var hero = new Hero();
        List<int> minAndMaxDamage = hero.CalculateMinAndMaxDamage();

        Assert.AreEqual(1, minAndMaxDamage[0]);
        Assert.AreEqual(1, minAndMaxDamage[1]);
    }

    [Test]
    public void GetSingleMinAndMaxDamage(
        [NUnit.Framework.Range(1, 10, 1)] int dices,
        [NUnit.Framework.Range(1, 10, 1)] int faces
        )
    {
        var hero = new Hero(dices, faces);

        List<int> minAndMaxDamage = hero.CalculateMinAndMaxDamage();

        Assert.AreEqual(dices, minAndMaxDamage[0]);
        Assert.AreEqual(dices * faces, minAndMaxDamage[1]);
    }

    [Test]
    public void GetComposedMinAndMaxDamage(
        [Values(new[] { 1, 2, 3 }, new[] { 2, 4, 6 })] int[] dices,
        [Values(new[] { 1, 2, 3 }, new[] { 2, 4, 6 })] int[] faces
        )
    {
        var hero = new Hero(dices, faces);

        List<int> minAndMaxDamage = hero.CalculateMinAndMaxDamage();

        int correctMinDamage = 0;
        int correctMaxDamage = 0;

        for (int i = 0; i < dices.Length; i++)
        {
            correctMinDamage += dices[i];
            correctMaxDamage += dices[i] * faces[i];

        }

        Assert.AreEqual(correctMinDamage, minAndMaxDamage[0]);
        Assert.AreEqual(correctMaxDamage, minAndMaxDamage[1]);
    }


    #endregion

    #region Ignored Test

    [Test]
    [Ignore("Ignore this")]
    public void IgnoreThisTest()
    {

    }

    #endregion
}
