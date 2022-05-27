using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : SkillBase
{
	//-----------
	//-***---***-
	//--**---**--
	//---*---*---
	public int centerX;

	public int centerY;

	public int size;

	public int distance;

	private const int _defaultSize = 3;

	private const int _defaultDistance = 3;

	public override void UseSkill( CharacterControllerBase source, CharacterControllerBase target )
	{
		base.UseSkill( source, target );
		float totalDamageAmount = -DealDoubleTriangleDamageToCharacter( source, amount );
		HealSelf( source, totalDamageAmount );
	}

	public override void RandomSet( CharacterControllerBase target, float amount )
	{
		base.RandomSet( target, amount );
		int width = target.character.width;
		int height = target.character.height;
		centerX = Random.Range( 0, width );
		centerY = Random.Range( 0, height );
		size = _defaultSize;
		distance = _defaultDistance;
	}

	public override void Set( CharacterControllerBase target, Vector2Int start, Vector2Int end, float amount )
	{
		base.Set( target, start, end, amount );
		centerX = start.x;
		centerY = start.y;
		size = _defaultSize;
		distance = (int)Vector2Int.Distance( start, end ) * 2;
	}

	public float DealDoubleTriangleDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int leftdamagePosition = new Vector2Int( centerX - distance / 2, centerY );
		Vector2Int rightdamagePosition = new Vector2Int( centerX + distance / 2, centerY );

		damage.GenerateRightUpTriangleHealthChangeMap( leftdamagePosition, size, damageAmount );
		damage.GenerateLeftUpTriangleHealthChangeMap( rightdamagePosition, size, damageAmount );
		return target.ChangeHealthPoint( damage.healthPointChangeMap );
	}

	public void HealSelf( CharacterControllerBase self, float totalHealAmount )
	{
		int width = self.character.width;
		int height = self.character.height;
		DamageBase damage = new DamageBase( width, height );
		PixelData[,] pixels = self.character.bodyMap;

		int alivePixel = 0;
		foreach( PixelData pixel in pixels )
		{
			if( pixel.moduleRef != null && pixel.currentHealthPoint > 0 )
			{
				alivePixel++;
			}
		}

		float healAmountPerPixel = totalHealAmount / (float)alivePixel;
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				if( pixels[x, y].moduleRef != null && pixels[x, y].currentHealthPoint > 0 )
				{
					damage.healthPointChangeMap[x, y] += healAmountPerPixel;
				}
			}
		}

		self.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
