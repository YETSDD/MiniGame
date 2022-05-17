using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( CharacterManager ) )]
public class CharacterManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		CharacterManager characterManager = (CharacterManager)target;

		if( GUILayout.Button( "GenerateAndShow" ) )
		{
			characterManager.playerCharacterObject = Utility.Generator.GenerateRandomCharacterData( characterManager.characterPrefab, characterManager.transform );
			CharacterDisplay playerCharacterDisplay = characterManager.playerCharacterObject.GetComponent<CharacterDisplay>();
			playerCharacterDisplay.InitializeMap( characterManager.playerCharacterObject.GetComponent<CharacterBase>().characterData, characterManager.playerCharacterObject.transform );
			playerCharacterDisplay.UpdateMap( characterManager.playerCharacterObject.GetComponent<CharacterBase>().characterData );
		}

		if( GUILayout.Button( "DestroyCharacter" ) )
		{
			if( characterManager.playerCharacterObject != null )
			{
				DestroyImmediate( characterManager.playerCharacterObject );
			}
		}
	}
}
