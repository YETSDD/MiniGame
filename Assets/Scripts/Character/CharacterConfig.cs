
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "character", menuName = "CharacterData/Character" )]
public class CharacterConfig : ScriptableObject, ISerializationCallbackReceiver
{
	public List<ModuleConfig> modules;

	public PixelData[] bodyMap_1D; 

	public PixelData[,] bodyMap;

	public int width, height;

	public bool isInitialized => bodyMap != null && modules != null;

	public void SetBodyMap( int width, int height )
	{
		if( width < 0 || height < 0 )
		{
			throw new System.Exception( "width or height" );
		}

		bodyMap = new PixelData[width, height];
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				bodyMap[x, y] = new PixelData();
			}
		}
	}

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
		bodyMap_1D = new PixelData[width * height];
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				bodyMap_1D[ x * width + y ] = bodyMap[x, y];
			}
		}
	}

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
		bodyMap = new PixelData[width, height];
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				bodyMap[x, y] = bodyMap_1D[ x * width + y ];
			}
		}
	}


}
