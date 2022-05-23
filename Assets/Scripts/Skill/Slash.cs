using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : SkillBase
{
	public int startX, startY;

	public int endX, endY;

	public override void UseSkill( CharacterControllerBase target )
	{
		base.UseSkill( target );

		DealLineDamageToCharacter( target, amount );
	}

	private void DealLineDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		Vector2Int startPixel = new Vector2Int( startX, startY );
		Vector2Int endPixel = new Vector2Int( endX, endY );
		DamageBase damage = new DamageBase( target.character.width, target.character.height );

		target.ChangeHealthPoint( damage.GenerateLineHealthPointChangeMap( startPixel, endPixel, damageAmount ) );
	}
}
