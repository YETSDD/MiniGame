using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : SkillBase
{
	public int cornerX;

	public int cornerY;

	public int damageWidth;

	public int damageHeight;

	public const int defaultDamageWidth = 5;

	public const int defaultDamageHeight = 5;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );
		DealRectDamageToCharacter( target, amount );
		HurtSelf( source, amount );
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
	public void DealRectDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( cornerX, cornerY );
		Vector2Int damageSize = new Vector2Int( damageWidth, damageHeight );
		RectInt damageRange = new RectInt( damagePosition, damageSize );

		damage.GenerateRectHealthPointChangeMap( damageRange, damageAmount );
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}

	public void HurtSelf( CharacterControllerBase self, float damageAmount )
	{
		int width = self.character.width;
		int height = self.character.height;
		DamageBase damage = new DamageBase( width, height );
		PixelData[,] pixels = self.character.bodyMap;

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				if( pixels[x, y].moduleRef == sourceModule.config && pixels[x, y].currentHealthPoint > 0 )
				{
					damage.healthPointChangeMap[x, y] -= pixels[x, y].currentHealthPoint;
				}
			}
		}

		self.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
