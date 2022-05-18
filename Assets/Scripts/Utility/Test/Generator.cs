using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
	public static class Generator
	{
		public static CharacterControllerBase GenerateRandomCharacterData( CharacterControllerBase characterPrefab, Transform parent )
		{
			int minWidth = 10, maxWidth = 30;
			int minHeight = 20, maxHeight = 30;
			int minHealthPoint = 1, maxHealthPoint = 100;

			CharacterControllerBase result = GameObject.Instantiate( characterPrefab, parent );

			result.character = new Character();
			result.character.SetBodyMap( Random.Range( minWidth, maxWidth ), Random.Range( minHeight, maxHeight ) );
			result.character.GenerateRandomMapData( minHealthPoint, maxHealthPoint );

			Debug.Log( "size:" + result.character.width + "," + result.character.height );

			return result;
		}

		public static CharacterControllerBase GenerateCharacterDataByConfig( CharacterControllerBase characterPrefab, Transform parent, CharacterConfig config )
		{
			CharacterControllerBase result = GameObject.Instantiate( characterPrefab, parent );

			result.character = new Character( config.width, config.height );
			result.character.InitializeByConfig( config );

			return result;
		}
	}
}

