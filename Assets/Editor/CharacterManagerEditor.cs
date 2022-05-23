using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( CharacterManager ) )]
public class CharacterManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		CharacterManager characterManager = (CharacterManager)target;


		if( GUILayout.Button( "GenerateRandomCharacterAndShow" ) )
		{
			CharacterControllerBase player = Utility.Generator.GenerateRandomCharacterData( characterManager.characterPrefab, characterManager.transform );
			characterManager.player = player;

			CharacterDisplay playerCharacterDisplay = player.characterDisplay;
			playerCharacterDisplay.InitializeMap( player.character, player.transform );
			playerCharacterDisplay.UpdateMap( player.character );
		}

		if( GUILayout.Button( "GenerateCharacterByConfigAndShow" ) )
		{
			CharacterControllerBase player = Utility.Generator.GenerateCharacterDataByConfig( characterManager.characterPrefab, characterManager.transform, characterManager.playerCharacterConfig );
			characterManager.player = player;

			CharacterDisplay playerCharacterDisplay = player.characterDisplay;
			playerCharacterDisplay.InitializeMap( player.character, player.transform );
			playerCharacterDisplay.UpdateMap( player.character );
		}

		if( GUILayout.Button( "DestroyCharacter" ) )
		{
			if( characterManager.player != null )
			{
				DestroyImmediate( characterManager.player.gameObject );
			}
		}
	}
}
