using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossCut : SkillBase
{
	public int centerX;

	public int centerY;

	public int size;

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
		size = Random.Range( 5, width );
	}

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		centerX = start.x;
		centerY = start.y;
		size = (int)Vector2Int.Distance( start, end );
	}

	public void DealPointDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( centerX, centerY );

		damage.GenerateCrossHealthPointCHangeMap( damagePosition, size, damageAmount );
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
