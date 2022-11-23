using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class OtherTestOfNaughtyAttribute : MonoBehaviour
{
    [Scene]
    public string bootScene; // scene name

    [ShowAssetPreview]
    public Sprite sprite;

	[BoxGroup("Integers")]
	public int firstInt;
	[BoxGroup("Integers")]
	public int secondInt;

	[BoxGroup("Floats")]
	public float firstFloat;
	[BoxGroup("Floats")]
	public float secondFloat;

	[Foldout("Integers")]
	public int thirdInt;
	[Foldout("Integers")]
	public int fourthInt;
	[Foldout("Integers")]
	public int fifthInt;

	public bool flag0;
	public bool flag1;

	[EnableIf(EConditionOperator.And, "flag0", "flag1")]
	public int enabledIfAll;

	[EnableIf(EConditionOperator.Or, "flag0", "flag1")]
	public int enabledIfAny;

	[Label("Short Name")]
	public string veryVeryLongName;

	[MinValue(0), MaxValue(10)]
	public int myInt;

	[MinValue(0.0f)]
	public float myFloat;

}
