using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiImpact : SkillBase
{
	public int cornerX;

	public int cornerY;

	public int damageWidth;

	public int damageHeight;

	public const int defaultDamageWidth = 5;

	public const int defaultDamageHeight = 3;

	public int count;

	private int _defaultCount = 3;

	private int _maxOffset = 5;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );
		DealMultiRectDamageToCharacter( target, amount );
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
		count = _defaultCount;
	}

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		cornerX = start.x - defaultDamageHeight / 2;
		cornerY = start.y - defaultDamageHeight / 2;
		damageWidth = defaultDamageWidth;
		damageHeight = defaultDamageHeight;
		count = _defaultCount;
	}
	public void DealMultiRectDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );

		for( int i = 0; i < count; i++ )
		{
			int randomOffsetX = Random.Range( -_maxOffset, _maxOffset );
			int randomOffsetY = Random.Range( -_maxOffset, _maxOffset );
			Vector2Int damagePosition = new Vector2Int( cornerX + randomOffsetX, cornerY + randomOffsetY );
			Vector2Int damageSize = new Vector2Int( damageWidth, damageHeight );
			RectInt damageRange = new RectInt( damagePosition, damageSize );

			damage.GenerateRectHealthPointChangeMap( damageRange, damageAmount );
		}
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
