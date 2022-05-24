using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBase : MonoBehaviour
{
	public string shownName;

	public SkillLimit limit;

	public float amount;

	public Image image;

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
