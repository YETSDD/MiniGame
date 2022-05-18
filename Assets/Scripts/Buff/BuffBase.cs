using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectRange
{
	Part,
	Global
}
public class BuffBase : MonoBehaviour
{
	public int remainRounds;

	public EffectRange range = EffectRange.Part;

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
