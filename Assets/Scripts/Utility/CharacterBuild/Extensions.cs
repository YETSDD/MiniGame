using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
	public struct ArrayToSerialize<T>
	{
		public T[] array;

		public int width, height;

	}

	public static class Extensions
	{
		public static T[,] Convert1DTo2D<T>( T[] array, int width, int height )
		{
			T[,] result = new T[width, height];
			for( int x = 0; x < width; x++ )
			{
				for( int y = 0; y < height; y++ )
				{
					result[x, y] = array[x * width + y];
				}
			}
			return result;
		}

		public static ArrayToSerialize<T> Convert2DTo1D<T>( T[,] array_2D )
		{
			ArrayToSerialize<T> arrayToSerialize = new ArrayToSerialize<T>();
			int width = array_2D.GetLength( 0 );
			int height = array_2D.GetLength( 1 );
			T[] array_1D = new T[width * height];
			for( int x = 0; x < width; x++ )
			{
				for( int y = 0; y < height; y++ )
				{
					array_1D[x * width + y] = array_2D[x, y];
				}
			}
			arrayToSerialize.width = width;
			arrayToSerialize.height = height;
			arrayToSerialize.array = array_1D;
			return arrayToSerialize;
		}
	}
}
