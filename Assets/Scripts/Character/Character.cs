using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
	public Module[] modules;

	public PixelData[,] bodyMap;

	public int width => bodyMap.GetLength( 0 );

	public int height => bodyMap.GetLength( 1 );

	public Character()
	{
	}

	public Character( int width, int height )
	{
		SetBodyMap( width, height );
	}

	public void SetBodyMap( int width, int height )
	{
		if( width > 0 && height > 0 )
		{
			bodyMap = new PixelData[width, height];
			for( int x = 0; x < width; x++ )
			{
				for( int y = 0; y < height; y++ )
				{
					bodyMap[x, y] = new PixelData();
				}
			}
		}
	}

	public void GenerateRandomMapData( int minHealthPoint, int maxHealthPoint )
	{
		if( bodyMap != null )
		{
			for( int i = 0; i < width; i++ )
			{
				for( int j = 0; j < height; j++ )
				{
					bodyMap[i, j] = new PixelData( Random.Range( minHealthPoint, maxHealthPoint ) );
				}
			}
		}
	}

	public void InitializeByConfig( CharacterConfig config ) { 
		LoadModuleFromConfig( config );
		LoadMapDataFromConfig( config );
	}

	private void LoadModuleFromConfig( CharacterConfig config ) {
		int length = config.modules.Count;
		modules = new Module[length];
		for( int i = 0; i < length; i++ ) { 
			modules[i] = new Module(config.modules[i]);
		}
	}

	private void LoadMapDataFromConfig( CharacterConfig config )
	{
		int width = config.width;
		int height = config.height;
		for( int x = 0; x < width; x++ ) {
			for( int y = 0; y < height; y++ ) {
				bodyMap[x, y].LoadPixelData( config.bodyMap_1D[x * width + y] );
			}
		}
	}
}
