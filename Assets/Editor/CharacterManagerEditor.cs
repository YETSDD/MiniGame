using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( CharacterManager ) )]
public class CharacterManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		CharacterManager characterManager = (CharacterManager)target;

		CharacterControllerBase player = characterManager.playerCharacter;
		if( GUILayout.Button( "GenerateRandomCharacterAndShow" ) )
		{
			player = Utility.Generator.GenerateRandomCharacterData( characterManager.characterPrefab, characterManager.transform );
			CharacterDisplay playerCharacterDisplay = player.characterDisplay;
			playerCharacterDisplay.InitializeMap( player.character, player.transform );
			playerCharacterDisplay.UpdateMap( player.character );
		}

		if( GUILayout.Button( "GenerateCharacterByConfigAndShow" ) )
		{
			player = Utility.Generator.GenerateCharacterDataByConfig( characterManager.characterPrefab, characterManager.transform, characterManager.playerCharacterConfig );
			CharacterDisplay playerCharacterDisplay = player.characterDisplay;
			playerCharacterDisplay.InitializeMap( player.character, player.transform );
			playerCharacterDisplay.UpdateMap( player.character );
		}

		if( GUILayout.Button( "DestroyCharacter" ) )
		{
			if( characterManager.playerCharacter != null )
			{
				DestroyImmediate( characterManager.playerCharacter.gameObject );
			}
		}
	}
}
