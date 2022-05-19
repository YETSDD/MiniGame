using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : SkillBase
{
	public int cornerX, cornerY;

	public int damageWidth, damageHeight;

	public override void ReleaseSkillToCharacter( CharacterControllerBase target )
	{
		base.ReleaseSkillToCharacter( target );
		DealRectDamageToCharacter( target, amount );
	}

	public void DealRectDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( cornerX, cornerY );
		Vector2Int damageSize = new Vector2Int( damageWidth, damageHeight );
		RectInt damageRange = new RectInt( damagePosition, damageSize );

		float[,] rectHealthPointChangeMap = damage.GenerateRectHealthPointChangeMap( damageRange, damageAmount );
		target.ChangeHealthPoint( rectHealthPointChangeMap );
	}
}
