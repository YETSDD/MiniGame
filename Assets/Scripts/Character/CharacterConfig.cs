
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "character", menuName = "Character/Character" )]
public class CharacterConfig : ScriptableObject, ISerializationCallbackReceiver
{
	public string characterName;

	public List<ModuleConfig> modules;

	[SerializeField]
	private PixelData[] _bodyMap_1D;

	public PixelData[,] bodyMap;

	public int width, height;

	public List<SkillBase> talentSkillPool;

	public bool isInitialized => bodyMap != null && modules != null;

	public void SetBodyMap( int width, int height )
	{
		if( width < 0 || height < 0 )
		{
			throw new System.Exception( "Invalid Width or Height" );
		}

		bodyMap = new PixelData[width, height];
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				bodyMap[x, y] = new PixelData();
			}
		}

		this.width = width;
		this.height = height;
	}

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
		_bodyMap_1D = new PixelData[width * height];
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				_bodyMap_1D[x * height + y] = bodyMap[x, y];
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
				if( _bodyMap_1D[x * height + y] == null )
					throw new System.Exception( "1D map error" );

				bodyMap[x, y] = _bodyMap_1D[x * height + y];
			}
		}
	}


}
