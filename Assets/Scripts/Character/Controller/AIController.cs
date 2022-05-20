using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		Prepare();
		self.OnRoundPrepare();
		Act();
		self.OnRoundAct();
		Settle();
		self.OnRoundSettle();
	}

	public override void Prepare()
	{
		SelectSkill();
	}

	/// <summary>
	/// 释放技能
	/// </summary>
	public override void Act()
	{
		StartCoroutine( PlayAnimation() );
		ReleaseSkill();
	}

	/// <summary>
	/// 特殊动作
	/// </summary>
	public override void Settle()
	{
		Debug.Log( "这里是一些特殊动作" );
	}

	protected virtual void SelectSkill()
	{
		RandomSelect();
	}

	protected virtual void ReleaseSkill()
	{
		RandomRelease();
	}

	private void RandomSelect()
	{
		//TODO: default empty skill
		_skillToRelease = Utility.Extensions.GetRandomElement( self.character.allAvailableSkills );
	}

	private void RandomRelease()
	{
		_skillToRelease.RandomSet( target, defaultSkillPower );
		_skillToRelease.ReleaseSkillToCharacter( target );
	}

	public virtual IEnumerator PlayAnimation()
	{
		yield return new WaitForSeconds( 1.0f );
	}
}
