using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionBase : MonoBehaviour
{
	public ActionLimit limit;
}

[System.Serializable]
public struct ActionLimit
{
	public float remainHealthPointPercentage;

	public int activePixels;
}
