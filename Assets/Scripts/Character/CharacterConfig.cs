
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "character", menuName = "CharacterData/Character" )]
public class CharacterConfig : ScriptableObject
{
	public List<ModuleConfig> modules;

	public PixelData[] bodyMap_1D;

	public int width, height;

	public bool isInitialized => bodyMap_1D != null && modules != null;

	public void SetBodyMap( int width, int height )
	{
		if( width > 0 && height > 0 )
		{
			bodyMap_1D = new PixelData[width * height];
			for( int x = 0; x < width; x++ )
			{
				for( int y = 0; y < height; y++ )
				{
					bodyMap_1D[x * width + y] = new PixelData();
				}
			}
		}
	}
}
