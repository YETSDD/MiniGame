using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : SkillBase
{
	public EffectRange range = EffectRange.Global;

	[HideInInspector]
	public Module targetModule;

	public override void UseSkill( CharacterControllerBase target )
	{
		base.UseSkill( target );

		switch( range )
		{
			case EffectRange.Part:
				HealModule( target );
				break;
			case EffectRange.Global:
				HealCharacter( target );
				break;
			default:
				break;
		}
	}

	private void HealCharacter( CharacterControllerBase target )
	{
		int width = target.character.width;
		int height = target.character.height;
		DamageBase damage = new DamageBase( width, height );
		PixelData[,] pixels = target.character.bodyMap;

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				if( pixels[x, y].moduleRef != null )
				{
					damage.healthPointChangeMap[x, y] = amount;
				}
			}
		}

		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}

	private void HealModule( CharacterControllerBase target )
	{
		if( targetModule == null )
		{
			throw new System.Exception( "TargetModule Not Initialized" );
		}

		int width = target.character.width;
		int height = target.character.height;
		DamageBase damage = new DamageBase( width, height );
		PixelData[,] pixels = target.character.bodyMap;

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				if( pixels[x, y].moduleRef == targetModule.config )
				{
					damage.healthPointChangeMap[x, y] = amount;
				}
			}
		}

		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
