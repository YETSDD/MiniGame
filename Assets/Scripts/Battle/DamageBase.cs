using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBase
{
	public float[,] healthPointChangeMap;

	private int _mapWidth;

	private int _mapHeight;

	private float _minAttenuationCoefficient = 0.5f;

	public DamageBase( int width, int height )
	{
		_mapWidth = width;
		_mapHeight = height;

		healthPointChangeMap = new float[_mapWidth, _mapHeight];
		for( int x = 0; x < _mapWidth; x++ )
		{
			for( int y = 0; y < _mapHeight; y++ )
			{
				healthPointChangeMap[x, y] = 0;
			}
		}
	}

	#region Uniform Damage

	public void GenerateRectHealthPointChangeMap( RectInt rect, float damageAmount )
	{
		for( int x = rect.xMin; x < rect.xMax; x++ )
		{
			for( int y = rect.yMin; y < rect.yMax; y++ )
			{
				if( x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight )
				{
					TrySetHealthPointChangeMap( x, y, -damageAmount );
				}
			}
		}
	}

	//-*-*-*--
	//-*****--
	//--***---
	//--***---
	//---*----
	public void GenerateTriangleHealthPointChangeMap( Vector2Int damagePosition, Vector2Int damageRange, float damageAmount )
	{
		//TODO: Attenuation
		float stepX = (float)damageRange.x / (float)( 2 * damageRange.y );

		for( int deltaY = 0; deltaY < damageRange.y; deltaY++ )
		{
			for( int i = -deltaY; i <= deltaY; i++ )
			{
				int x = damagePosition.x + (int)( i * stepX );
				TrySetHealthPointChangeMap( x, damagePosition.y + deltaY, -damageAmount );
			}
		}

		for( int i = -damageRange.x / 2; i <= damageRange.x / 2; i++ )
		{
			if( i % 2 == 0 )
			{
				int x = damagePosition.x + i;
				TrySetHealthPointChangeMap( x, damagePosition.y + damageRange.y, -damageAmount );
			}
		}
	}

	/// <summary>
	/// 使用DDA增量法计算直线
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <param name="damageAmount"></param>
	public void GenerateLineHealthPointChangeMap( Vector2Int start, Vector2Int end, float damageAmount )
	{
		int steps = Mathf.Max( Mathf.Abs( end.x - start.x ), Mathf.Abs( end.y - start.y ) );
		float deltaX = (float)( end.x - start.x ) / steps;
		float deltaY = (float)( end.y - start.y ) / steps;
		float x = start.x;
		float y = start.y;

		for( int i = 0; i <= steps; i++ )
		{
			TrySetHealthPointChangeMap( (int)x, (int)y, -damageAmount );
			x += deltaX;
			y += deltaY;
		}
	}

	/// <summary>
	/// 计算线段
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <param name="damageAmount"></param>
	public void GenerateLimitedLineHealthPointChangeMap( Vector2Int start, Vector2Int end, float damageAmount, int size )
	{
		int steps = Mathf.Max( Mathf.Abs( end.x - start.x ), Mathf.Abs( end.y - start.y ) );
		float deltaX = (float)( end.x - start.x ) / steps;
		float deltaY = (float)( end.y - start.y ) / steps;
		float x = start.x;
		float y = start.y;

		for( int i = 0; i <= Mathf.Min( steps, size ); i++ )
		{
			TrySetHealthPointChangeMap( (int)x, (int)y, -damageAmount );
			x += deltaX;
			y += deltaY;
		}
	}

	public void GenerateCrossHealthPointCHangeMap( Vector2Int center, int size, float damageAmount )
	{
		int startX = center.x - size / 2;
		int endX = center.x + size / 2;
		int startY = center.y - size / 2;
		int endY = center.y + size / 2;
		for( int i = -size / 2; i <= size / 2; i++ )
		{
			//( 1-x, 1+x ) is to set averange damage amount to damageAmount
			float factor = Mathf.Lerp( _minAttenuationCoefficient, 1.0f + _minAttenuationCoefficient, (float)( size / 2 - Mathf.Abs( i ) ) / (float)size );

			TrySetHealthPointChangeMap( i + center.x, center.y, -damageAmount * factor );
			TrySetHealthPointChangeMap( center.x, i + center.y, -damageAmount * factor );
		}
	}

	public void GenerateRightUpTriangleHealthChangeMap( Vector2Int corner, int size, float damageAmount )
	{
		for( int deltaX = size - 1; deltaX >= 0; deltaX-- )
		{
			for( int deltaY = 0; deltaY + deltaX < size; deltaY++ )
			{
				TrySetHealthPointChangeMap( corner.x - deltaX, corner.y - deltaY, -damageAmount );
			}
		}
	}

	public void GenerateLeftUpTriangleHealthChangeMap( Vector2Int corner, int size, float damageAmount )
	{
		for( int deltaX = size - 1; deltaX >= 0; deltaX-- )
		{
			for( int deltaY = 0; deltaY + deltaX < size; deltaY++ )
			{
				TrySetHealthPointChangeMap( corner.x + deltaX, corner.y - deltaY, -damageAmount );
			}
		}

	}

	private void TrySetHealthPointChangeMap( int x, int y, float amount )
	{
		if( x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight )
		{
			healthPointChangeMap[x, y] += amount;
		}
	}
	#endregion
}
