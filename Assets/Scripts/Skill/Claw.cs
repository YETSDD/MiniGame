using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : SkillBase
{
	public int startX;

	public int startY;

	public int endX;

	public int endY;

	public int size;

	private const int _defaultSize = 7;

	public int spacing;

	private const int _defaultSpacing = 3;

	public int count;

	public const int _defaultCount = 3;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );

		DealMultiplyLimitedLineDamageToCharacter( target, defaultAmount );
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
		size = _defaultSize;
		spacing = _defaultSpacing;
		count = _defaultCount;
	}

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		startX = start.x;
		startY = start.y;
		endX = end.x;
		endY = end.y;
		size = _defaultSize;
		spacing = _defaultSpacing;
		count = _defaultCount;
	}

	private void DealMultiplyLimitedLineDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		if( endY == startY )
		{
			for( int i = 0; i < count; i++ )
			{
				int offsetY = Mathf.CeilToInt( ( i - count / 2 ) * spacing );
				Vector2Int startPixel = new Vector2Int( startX, startY + offsetY );
				Vector2Int endPixel = new Vector2Int( endX, endY + offsetY );
				damage.GenerateLimitedLineHealthPointChangeMap( startPixel, endPixel, damageAmount, size );
			}
		}

		float k = -(float)( startX - endX ) / (float)( startY - endY );
		int stepX = Mathf.CeilToInt( Mathf.Sqrt( spacing * spacing / ( k * k + 1 ) ) );
		int stepY = (int)( stepX * k );

		for( int i = 0; i < count; i++ )
		{
			int offsetX = ( i - count / 2 ) * stepX;
			int offsetY = ( i - count / 2 ) * stepY;
			Vector2Int startPixel = new Vector2Int( startX + offsetX, startY + offsetY );
			Vector2Int endPixel = new Vector2Int( endX + offsetX, endY + offsetY );

			damage.GenerateLineHealthPointChangeMap( startPixel, endPixel, damageAmount);
		}
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
