using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{//TODO: Redesign element type
	None,
	Air,
	Earth,
	Fire,
	Water
}



[System.Serializable]
public class PixelData
{
	public float currentHealthPoint;

	public const float maxHealthPoint = 255.0f;

	public ElementType elementType = ElementType.None;

	public ModuleConfig moduleRef;

	public float damageFactor = 1.0f;

	public PixelData( float healthPoint = 0, ModuleConfig module = null )
	{
		this.currentHealthPoint = healthPoint;
		this.moduleRef = module;
	}

	public float ChangeHealthPoint( float amount )
	{
		float current = currentHealthPoint;
		float factor = amount < 0 ? damageFactor : 1.0f;

		currentHealthPoint += amount * factor;
		if( currentHealthPoint < 0 )
		{
			currentHealthPoint = 0;
			return current;
		}

		if( currentHealthPoint > maxHealthPoint )
		{
			currentHealthPoint = maxHealthPoint;
			return maxHealthPoint - current;
		}
		return amount * factor;
	}

	public void LoadPixelData( PixelData pixelData )
	{
		currentHealthPoint = pixelData.currentHealthPoint;
		elementType = pixelData.elementType;
		moduleRef = pixelData.moduleRef;
		damageFactor = pixelData.damageFactor;
	}
}
