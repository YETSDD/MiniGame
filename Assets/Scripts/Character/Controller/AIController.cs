using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AIController : BehaviourControllerBase
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
	}

	public override void Act()
	{
		Debug.Log( "Act" );
		StartCoroutine( PlayAnimation() );
		UseSkill();
	}

	public override void End()
	{
		Debug.Log( "End" );
	}

	protected virtual void SelectSkill()
	{
		RandomSelect();
	}

	protected virtual void UseSkill()
	{
		RandomUse();
	}

	private void RandomSelect()
	{
		//TODO: default empty skill
		_skillToRelease = self.character.allAvailableSkills.GetRandomElement();
	}

	private void RandomUse()
	{
		_skillToRelease.RandomSet( target, defaultSkillPower );
		_skillToRelease.UseSkill( target );
	}

	public virtual IEnumerator PlayAnimation()
	{
		yield return new WaitForSeconds( 1.0f );
	}
}


public enum AIType
{
	Slime
}