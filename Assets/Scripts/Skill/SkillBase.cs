using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillBase : MonoBehaviour
{
	public SkillLimit limit;

	public float amount;

	public virtual void UseSkill( CharacterControllerBase target )
	{
		if( amount == float.NaN )
		{
			throw new System.Exception( "Amount Not Initialized" );
		}
	}

	public virtual void RandomSet( CharacterControllerBase target, float amount )
	{
		this.amount = amount;
	}
}

[System.Serializable]
public struct SkillLimit
{
	public float remainHealthPoint;

	public int activePixels;
}
