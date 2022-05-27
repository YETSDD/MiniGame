using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puncture : SkillBase
{
	public int centerX;

	public int centerY;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );
		DealPointDamageToCharacter( source, amount );
	}

	public override void RandomSet( CharacterControllerBase target, float amount )
	{
		base.RandomSet( target, amount );
		int width = target.character.width;
		int height = target.character.height;
		centerX = Random.Range( 0, width );
		centerY = Random.Range( 0, height );
	}

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		centerX = start.x;
		centerY = start.y;
	}

	public void DealPointDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( centerX, centerY );

		damage.GenerateCrossHealthPointCHangeMap( damagePosition, 3, damageAmount );
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
