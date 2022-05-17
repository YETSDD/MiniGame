
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "character", menuName = "CharacterData/Character" )]
public class CharacterConfig : ScriptableObject
{
	public List<ModuleConfig> modules;

	public PixelData[,] bodyMap;//TODO: ÐòÁÐ»¯´¢´æ

	public void SetBodyMap( int width, int height )
	{
		if( width > 0 && height > 0 )
		{
			bodyMap = new PixelData[width, height];
			for( int i = 0; i < width; i++ ) {
				for( int j = 0; j < height; j++ ) {
					bodyMap[i, j] = new PixelData(10);
				}
			}
		}
		
	}

	public bool isInitialized()
	{
		return bodyMap != null && modules != null;
	}

	public void InitializeBodyMap() { 
		
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
