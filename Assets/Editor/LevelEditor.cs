using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( LevelChanger ) )]
public class LevelEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		LevelChanger levelChanger = (LevelChanger)target;
		List<CharacterConfig> levelConfigs = levelChanger.configs;
		List<AIController> levelControllers = levelChanger.controllers;

		if( GUILayout.Button( "LoadLevel" ) )
		{
			levelConfigs.Clear();
			levelControllers.Clear();
			foreach( (CharacterConfig, AIController) pair in levelChanger.level.monsters )
			{
				levelConfigs.Add( pair.Item1 );
				levelControllers.Add( pair.Item2 );
			}
		}

		if( GUILayout.Button( "SaveLevel" ) )
		{
			levelChanger.level.monsters.Clear();
			for( int i = 0; i < Mathf.Min( levelConfigs.Count, levelControllers.Count ); i++ )
			{
				levelChanger.level.monsters.Add( (levelConfigs[i], levelControllers[i]) );
			}
		}
	}
}
