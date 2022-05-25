using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class BasicAIController : BehaviourControllerBase
{
	public CharacterControllerBase target;

	private SkillBase _skillToRelease;

	public const float defaultSkillPower = 10.0f;

	public override void OnTurn()
	{
		if( self == null )
		{
			throw new System.Exception( "Monster Not Initialized" );
		}

		if( target == null )
		{
			throw new System.Exception( "Target of Monster Not Selected" );
		}
	}

	public override void Prepare()
	{
		Debug.Log( "Prepare" );
		SelectSkill();
		PrepareOver();
	}

	public override void Act()
	{
		Debug.Log( "Act" );
		StartCoroutine( PlayAnimation() );
		UseSkill();
		ActOver();
	}

	public override void End()
	{
		Debug.Log( "End" );
		RoundOver();
	}

	protected virtual void SelectSkill()
	{
		RandomSelect();
		_skillToRelease.RandomSet( target, defaultSkillPower );
	}

	protected virtual void UseSkill()
	{
		_skillToRelease.UseSkill( target );
	}

	private void RandomSelect()
	{
		//TODO: default empty skill
		_skillToRelease = self.character.allAvailableSkills.GetRandomElement();
	}

	public virtual IEnumerator PlayAnimation()
	{
		yield return new WaitForSeconds( 1.0f );
	}
}


public enum AIType
{
	Basic,
	Slime
}