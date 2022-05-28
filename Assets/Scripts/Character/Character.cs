using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
	public Module[] modules;

	public PixelData[,] bodyMap;

	public int width => bodyMap.GetLength( 0 );

	public int height => bodyMap.GetLength( 1 );

	public SkillBase basicSkill; //TODO: Player choose talent skills.

	public List<SkillBase> allAvailableSkills = new List<SkillBase>();

	public Character()
	{
	}

	public Character( int width, int height )
	{
		SetBodyMap( width, height );
	}

	public Character( CharacterConfig config )
	{
		InitializeByConfig( config );
	}

	public void SetBodyMap( int width, int height )
	{
		if( width <= 0 || height <= 0 )
		{
			throw new System.Exception( "Invalid Width or Height " );
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

	public void GenerateRandomMapData( int minHealthPoint, int maxHealthPoint )
	{
		if( bodyMap == null )
		{
			throw new System.Exception( "Null BodyMap" );
		}

		for( int i = 0; i < width; i++ )
		{
			for( int j = 0; j < height; j++ )
			{
				bodyMap[i, j] = new PixelData( Random.Range( minHealthPoint, maxHealthPoint ) );
			}
		}
	}

	public void InitializeByConfig( CharacterConfig config )
	{
		LoadModuleFromConfig( config );
		LoadMapDataFromConfig( config );
		InitializeAvailableSkills();
	}

	private void LoadModuleFromConfig( CharacterConfig config )
	{
		int length = config.modules.Count;
		modules = new Module[length];
		for( int i = 0; i < length; i++ )
		{
			modules[i] = new Module( config.modules[i], this );

		}
	}

	private void LoadMapDataFromConfig( CharacterConfig config )
	{
		int width = config.width;
		int height = config.height;
		if( bodyMap == null )
		{
			SetBodyMap( width, height );
		}

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				bodyMap[x, y].LoadPixelData( config.bodyMap[x, y] );
			}
		}
	}

	public void InitializeAvailableSkills()
	{
		allAvailableSkills.Clear();
		if( basicSkill != null )
		{
			allAvailableSkills.Add( basicSkill );
		}

		foreach( Module module in modules )
		{
			module.EvaluateAvailableSkills();
			allAvailableSkills.AddRange( module.availableSkills );
		}
	}

	public void RandomSetAllModules()
	{
		foreach( Module module in modules )
		{
			module.SetRandomSkillSet();
		}
	}

	public void OnDestroy()
	{
		foreach( Module module in modules )
		{
			for( int i = module.skillInstances.Count - 1; i >= 0; i-- )
			{
				SkillBase skill = module.skillInstances[i];
				module.skillInstances.RemoveAt( i );
				GameObject.Destroy( skill.gameObject );
			}
		}
	}
}
