using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillBase : MonoBehaviour
{
	public SkillLimit limit;

	public float amount;

	public virtual void ReleaseSkillToCharacter( CharacterControllerBase target )
	{
		if( amount == float.NaN )
		{
			throw new System.Exception( "Amount Not Initialized" );
		}
	}
}

[System.Serializable]
public struct SkillLimit
{
	public float remainHealthPoint;

	public int activePixels;
}
