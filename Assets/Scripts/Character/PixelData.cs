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

	public ElementType elementType = ElementType.None;

	public ModuleConfig moduleRef;

	public float damageFactor = 1.0f;

	public PixelData( float healthPoint = 0, ModuleConfig module = null )
	{
		this.currentHealthPoint = healthPoint;
		this.moduleRef = module;
	}

	public void ChangeHealthPoint( float amount )
	{
		float factor = amount < 0 ? damageFactor : 1.0f;

		currentHealthPoint += amount * factor;
		if( currentHealthPoint < 0 )
		{
			currentHealthPoint = 0;
		}
	}

	public void LoadPixelData( PixelData pixelData )
	{
		currentHealthPoint = pixelData.currentHealthPoint;
		elementType = pixelData.elementType;
		moduleRef = pixelData.moduleRef;
		damageFactor = pixelData.damageFactor;
	}
}
