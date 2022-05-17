using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase
{
	public float[,] healthPointChangeMap;

	private int _mapWidth;

	private int _mapHeight;

	public DamageBase( int width, int height )
	{
		_mapWidth = width;
		_mapHeight = height;
	}

	#region Uniform  Damage
	public float[,] GenerateRectHealthPointChangeMap(RectInt rect, int damageAmount)
	{
		float[,] result = new float[_mapWidth,_mapHeight];

		for( int i = rect.xMin ; i < rect.xMax; i++ )
		{
			for( int j = rect.yMin; j < rect.yMax; j++ )
			{
				if( i >= 0 && i < _mapWidth && j >= 0 && j < _mapHeight )
				{
					result[i, j] = damageAmount;
				}
			}
		}
		return result;
	}
	#endregion

}
