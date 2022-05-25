using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : SkillBase
{
	public int startX;

	public int startY;

	public int endX;

	public int endY;

	public override void UseSkill( CharacterControllerBase target )
	{
		base.UseSkill( target );

		DealLineDamageToCharacter( target, amount );
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

		target.ChangeHealthPoint( damage.GenerateLineHealthPointChangeMap( startPixel, endPixel, damageAmount ) );
	}
}
