using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectRange
{
	part,
	global
}
public class BuffBase : MonoBehaviour
{
	public int remainRounds;

	public EffectRange range = EffectRange.part;

	public virtual void AddToCharacter( CharacterControllerBase target )
	{
	}

	public virtual void OnBuffStart()
	{
	}

	public virtual void OnBuffUpdate()
	{
	}

	public virtual void OnBuffDestroy()
	{
	}

}
