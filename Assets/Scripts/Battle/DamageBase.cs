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

	public void GenerateRectHealthPointChangeMap( RectInt rect, float damageAmount )
	{
		for( int x = rect.xMin; x < rect.xMax; x++ )
		{
			for( int y = rect.yMin; y < rect.yMax; y++ )
			{
				if( x >= 0 && x < _mapWidth && y >= 0 && y < _mapHeight )
				{
					healthPointChangeMap[x, y] = -damageAmount * 10.0f;
				}
			}
		}
	}

	/// <summary>
	/// ʹ��DDA������������Ч����
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <param name="damageAmount"></param>
	public void GenerateLineHealthPointChangeMap( Vector2Int start, Vector2Int end, float damageAmount )
	{
		float increX, increY; //x��y���������
		float x, y;
		int steps;   //ѭ�������������ĵ���
		steps = Mathf.Max( Mathf.Abs( end.x - start.x ), Mathf.Abs( end.y - start.y ) );//ѡ�ϴ�����Ϊ��������
		increX = (float)( end.x - start.x ) / steps;//x��������
		increY = (float)( end.y - start.y ) / steps;//y��������
		x = start.x;
		y = start.y;

		for( int i = 1; i <= steps; i++ )
		{
			healthPointChangeMap[(int)x, (int)y] = -damageAmount * 100.0f;
			x += increX;
			y += increY;
		}

	}

	#endregion


}
