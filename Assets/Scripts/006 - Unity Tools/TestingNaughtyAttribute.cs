using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TestingNaughtyAttribute : MonoBehaviour
{
	public enum Direction
	{
		None = 0,
		Right = 1 << 0,
		Left = 1 << 1,
		Up = 1 << 2,
		Down = 1 << 3
	}

	[ProgressBar("Health", 300, EColor.Red)]
	public int health = 250;

	[ProgressBar("Mana", 100, EColor.Blue)]
	public int mana = 25;

	[ProgressBar("Stamina", 200, EColor.Green)]
	public int stamina = 150;

	[Button]
	public void MethodOne() { }

	[Button("Button Text")]
	public void MethodTwo() { }

	[Dropdown("intValues")]
	public int intValue;

	private int[] intValues = new int[] { 1, 2, 3, 4, 5 };

	[EnumFlags]
	public Direction flags;

	[Expandable]
	public ExpandableObject scriptableObject;

	[HorizontalLine(color: EColor.Red)]
	public int red;

	[HorizontalLine(color: EColor.Green)]
	public int green;

	[HorizontalLine(color: EColor.Blue)]
	public int blue;

	[InfoBox("This is my int", EInfoBoxType.Normal)]
	public int myInt;

	[InfoBox("This is my float", EInfoBoxType.Warning)]
	public float myFloat;

	[InfoBox("This is my vector", EInfoBoxType.Error)]
	public Vector3 myVector;

	[InputAxis]
	public string inputAxis;

	[MinMaxSlider(0.0f, 100.0f)]
	public Vector2 minMaxSlider;

	[ReorderableList]
	public int[] intArray;

	[ReadOnly]
	public Vector3 forwardVector = Vector3.forward;

	[ResizableTextArea]
	public string resizableTextArea;

	[Scene]
	public string bootScene; // scene name
}
