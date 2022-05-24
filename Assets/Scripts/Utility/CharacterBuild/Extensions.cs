using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

		public static T GetRandomElement<T>( this List<T> list )
		{
			if( list.Count == 0 )
			{
				throw new System.Exception( "Empty List" );
			}

			int index = Random.Range( 0, list.Count );
			return list[index];
		}

		public static List<T> GetRandomElements<T>( this List<T> list, int amount )
		{
			if( list.Count == 0 )
			{
				throw new System.Exception( "Empty List" );
			}

			if( list.Count < amount )
			{
				throw new System.Exception( "Amount Out of Range" );
			}

			HashSet<T> result = new HashSet<T>();
			while( result.Count < amount )
			{
				result.Add( list[Random.Range( 0, list.Count )] );
			}

			return new List<T>( result );
		}

		public static List<KeyValuePair<T1, T2>> GetRandomElements<T1, T2>( this Dictionary<T1, List<T2>> dictionary, int amount )
		{
			if( dictionary.Count == 0 )
			{
				throw new System.Exception( "Empty Dictionary" );
			}

			int totalAmount = 0;
			foreach( List<T2> list in dictionary.Values )
			{
				totalAmount += list.Count;
			}
			if( totalAmount < amount )
			{
				throw new System.Exception( "Amount Out of Range" );
			}

			HashSet<KeyValuePair<T1, T2>> result = new HashSet<KeyValuePair<T1, T2>>();
			List<T1> keys = Enumerable.ToList( dictionary.Keys );

			while( result.Count < amount )
			{
				int randomPairIndex = Random.Range( 0, keys.Count );
				List<T2> list = dictionary[keys[randomPairIndex]];
				result.Add( new KeyValuePair<T1, T2>( keys[randomPairIndex], list[Random.Range( 0, list.Count )] ) );
			}

			return new List<KeyValuePair<T1, T2>>( result );

		}
	}
}
