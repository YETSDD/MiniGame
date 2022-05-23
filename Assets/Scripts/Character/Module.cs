using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Module
{
	public ModuleConfig config;

	public List<BuffBase> buffs;

	public SkillSet skillSet;

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

	public void SetRandomSkillSet()
	{
		this.skillSet = Utility.Extensions.GetRandomElement( config.skillSetPool );
	}

	public void EvaluateAvailableSkills()
	{
		if( skillSet == null )
		{
			throw new System.Exception( "Empty Skill Set" );
		}

		foreach( SkillBase skill in skillSet.ownSkills )
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
