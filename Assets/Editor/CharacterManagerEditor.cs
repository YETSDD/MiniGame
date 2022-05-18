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
			characterManager.playerCharacter = Utility.Generator.GenerateRandomCharacterData( characterManager.characterPrefab, characterManager.transform );
			CharacterDisplay playerCharacterDisplay = characterManager.playerCharacter.characterDisplay;
			playerCharacterDisplay.InitializeMap( characterManager.playerCharacter.character, characterManager.playerCharacter.transform );
			playerCharacterDisplay.UpdateMap( characterManager.playerCharacter.character );
		}

		if( GUILayout.Button( "GenerateCharacterByConfigAndShow" ) )
		{
			characterManager.playerCharacter = Utility.Generator.GenerateCharacterDataByConfig( characterManager.characterPrefab, characterManager.transform, characterManager.playerCharacterConfig );
			CharacterDisplay playerCharacterDisplay = characterManager.playerCharacter.characterDisplay;
			playerCharacterDisplay.InitializeMap( characterManager.playerCharacter.character, characterManager.playerCharacter.transform );
			playerCharacterDisplay.UpdateMap( characterManager.playerCharacter.character );
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
