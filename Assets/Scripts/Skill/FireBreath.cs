using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : SkillBase
{
	public int cornerX;

	public int cornerY;

	public int damageWidth;

	public int damageHeight;

	public const int defaultDamageWidth = 5;

	public const int defaultDamageHeight = 4;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );
		DealTriangleDamageToCharacter( target, amount );
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

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		cornerX = start.x;
		cornerY = start.y;
		damageWidth = defaultDamageWidth;
		damageHeight = defaultDamageHeight;

	}
	public void DealTriangleDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( cornerX, cornerY );
		Vector2Int damageSize = new Vector2Int( damageWidth, damageHeight );

		damage.GenerateTriangleHealthPointChangeMap( damagePosition, damageSize, damageAmount );
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
