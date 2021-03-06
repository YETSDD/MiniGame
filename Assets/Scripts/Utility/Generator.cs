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

			result.character = new Character( Random.Range( minWidth, maxWidth ), Random.Range( minHeight, maxHeight ) );
			result.character.GenerateRandomMapData( minHealthPoint, maxHealthPoint );

			return result;
		}

		public static CharacterControllerBase GenerateCharacterDataByConfig( CharacterControllerBase characterPrefab, Transform parent, CharacterConfig config )
		{
			CharacterControllerBase result = GameObject.Instantiate( characterPrefab, parent );

			result.character = new Character( config );
			

			return result;
		}

		public static CharacterControllerBase GenerateMonster( CharacterControllerBase characterPrefab, Transform parent, CharacterConfig config )
		{
			CharacterControllerBase result = GenerateCharacterDataByConfig( characterPrefab, parent, config );
			result.character.RandomSetAllModules();

			return result;
		}

		public static CharacterControllerBase GeneratePlayer( CharacterControllerBase characterPrefab, Transform parent, CharacterConfig config )
		{
			CharacterControllerBase result = GenerateCharacterDataByConfig( characterPrefab, parent, config );

			return result;
		}

	}
}

