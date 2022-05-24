using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : SkillBase
{
	public int cornerX;

	public int cornerY;

	public int damageWidth;

	public int damageHeight;

	public override void UseSkill( CharacterControllerBase target )
	{
		base.UseSkill( target );
		DealRectDamageToCharacter( target, amount );
	}

	public override void RandomSet( CharacterControllerBase target, float amount )
	{
		base.RandomSet( target, amount );
		int width = target.character.width;
		int height = target.character.height;
		cornerX = Random.Range( 0, width );
		cornerY = Random.Range( 0, height );
		damageWidth = Random.Range( 0, width );
		damageHeight = Random.Range( 0, height );
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
