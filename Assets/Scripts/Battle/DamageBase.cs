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
		healthPointChangeMap = new float[_mapWidth, _mapHeight];
	}

	#region Uniform Damage

	public float[,] GenerateRectHealthPointChangeMap( RectInt rect, float damageAmount )
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

	public float[,] GenerateLineHealthPointChangeMap( Vector2Int start, Vector2Int end, float damageAmount )
	{
		float[,] result = new float[_mapWidth, _mapHeight];

		//TODO: Calculate effected pixels
		throw new System.Exception( "Not Implement" );
	}

	#endregion


}
