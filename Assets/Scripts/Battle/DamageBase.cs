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

	#region Uniform Damage

	public float[,] GenerateRectHealthPointChangeMap( RectInt rect, int damageAmount )
	{
		float[,] result = new float[_mapWidth, _mapHeight];

		for( int x = rect.xMin; x < rect.xMax; x++ )
		{
			for( int y = rect.yMin; y < rect.yMax; y++ )
			{
				if( x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight )
				{
					result[x, y] = damageAmount;
				}
			}
		}
		return result;
	}

	#endregion

}
