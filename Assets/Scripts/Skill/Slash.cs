using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : SkillBase
{
	public int startX;

	public int startY;

	public int endX;

	public int endY;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );

		DealLineDamageToCharacter( target, amount );
	}

	public override void RandomSet( CharacterControllerBase target, float amount )
	{
		base.RandomSet( target, amount );
		int width = target.character.width;
		int height = target.character.height;
		startX = Random.Range( 0, width );
		startY = Random.Range( 0, height );
		endX = Random.Range( 0, width );
		endY = Random.Range( 0, height );
	}

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		startX = start.x;
		startY = start.y;
		endX = end.x;
		endY = end.y;
	}

	private void DealLineDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		Vector2Int startPixel = new Vector2Int( startX, startY );
		Vector2Int endPixel = new Vector2Int( endX, endY );
		DamageBase damage = new DamageBase( target.character.width, target.character.height );

		damage.GenerateLineHealthPointChangeMap( startPixel, endPixel, damageAmount );
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
