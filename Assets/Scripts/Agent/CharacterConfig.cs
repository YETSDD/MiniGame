
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "character", menuName = "CharacterData/Character" )]
public class CharacterConfig : ScriptableObject
{
	public List<ModuleConfig> modules;

	public PixelData[,] bodyMap;//TODO: ÐòÁÐ»¯´¢´æ

	public void SetBodyMap( int length, int width )
	{
		if( length > 0 && width > 0 )
		{
			bodyMap = new PixelData[length, width];
		}
	}

	public bool isInitialized()
	{
		return bodyMap != null && modules != null;
	}
	public void GenerateRandomMapData()
	{
		if( bodyMap != null )
		{
			for( int i = 0; i < bodyMap.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < bodyMap.GetLength( 1 ); j++ )
				{
					bodyMap[i, j] = new PixelData( Random.Range( 1, 100 ) );
				}
			}
		}
	}
}
