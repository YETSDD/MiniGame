using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Module
{
	public ModuleConfig config;

	public List<BuffBase> buffs;

	public SkillSet skillSet { get; private set; }

	public List<SkillBase> skillInstances = new List<SkillBase>();

	public List<SkillBase> availableSkills = new List<SkillBase>();

	public List<SkillBase> unavailableSkills = new List<SkillBase>();

	public Module( ModuleConfig config )
	{
		this.config = config;
		this.skillSet = config.defaultSkillSet;
		EvaluateAvailableSkills();
	}

	public Module( ModuleConfig config, SkillSet skillSet )
	{
		this.config = config;
		this.skillSet = skillSet;
		EvaluateAvailableSkills();
	}

	public void SetSkillSet( SkillSet skillSet )
	{
		this.skillSet = skillSet;
		EvaluateAvailableSkills();
	}

	public void BindSkillToModule()
	{
		foreach( SkillBase skill in skillInstances )
		{
			skill.sourceModule = this;
		}
	}

	public void SetRandomSkillSet()
	{//TODO: to use
		this.skillSet = Utility.Extensions.GetRandomElement( config.skillSetPool );
		EvaluateAvailableSkills();
	}

	public void EvaluateAvailableSkills()
	{

		if( skillSet == null || skillSet.ownSkills.Count == 0 )
		{
			throw new System.Exception( "Empty Skill Set" );
		}

		ClearSkills();
		foreach( SkillBase skill in skillSet.ownSkills )
		{
			SkillBase instance = GameObject.Instantiate( skill, CharacterManager.instance.transform );
			skillInstances.Add( instance );
		}


		availableSkills.Clear();
		unavailableSkills.Clear();

		foreach( SkillBase skill in skillInstances )
		{
			if( JudgeIfActive( skill ) )
			{
				availableSkills.Add( skill );
			}
			else
			{
				unavailableSkills.Add( skill );
			}
		}
		BindSkillToModule();
	}

	public void ClearSkills()
	{
		for( int i = skillInstances.Count - 1; i >= 0; i-- )
		{
			SkillBase skill = skillInstances[i];
			skillInstances.RemoveAt( i );
			GameObject.Destroy( skill.gameObject );
		}

	}

	public bool JudgeIfActive( SkillBase skill )
	{
		float totalHealthPoint = 0;
		int activePixels = 0;
		foreach( PixelData pixel in config.ownPixels )
		{
			totalHealthPoint += pixel.currentHealthPoint;
			if( pixel.currentHealthPoint > 0 )
			{
				activePixels++;
			}
		}

		SkillLimit limit = skill.limit;
		return totalHealthPoint > limit.remainHealthPoint && activePixels > limit.activePixels;
	}
}
