using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeFoot : SkillBase
{
	public int cornerX;

	public int cornerY;

	public int damageWidth;

	public int damageHeight;

	public const int defaultDamageWidth = 5;

	public const int defaultDamageHeight = 5;

	private const int _defaultFingerCount = 3;

	private const int _defaultFingerLength = 5;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );
		DealBladeFootDamageToCharacter( target, amount );
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
		cornerX = start.x - defaultDamageHeight / 2;
		cornerY = start.y - defaultDamageHeight / 2;
		damageWidth = defaultDamageWidth;
		damageHeight = defaultDamageHeight;

	}
	public void DealBladeFootDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( cornerX, cornerY );
		Vector2Int damageSize = new Vector2Int( damageWidth, damageHeight );
		RectInt damageRange = new RectInt( damagePosition, damageSize );

		damage.GenerateRectHealthPointChangeMap( damageRange, damageAmount );
		for( int i = 0; i < _defaultFingerCount; i++ )
		{
			int offsetX = i * (int)( (float)damageWidth / (float)_defaultFingerCount );
			int offsetY = _defaultFingerLength;
			Vector2Int start = new Vector2Int( cornerX + offsetX, cornerY );
			Vector2Int end = new Vector2Int( cornerX + offsetX, cornerY + offsetY );
			damage.GenerateLimitedLineHealthPointChangeMap( start, end, amount, _defaultFingerLength );
		}
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
