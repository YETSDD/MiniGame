using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
	public static class Generator
	{
		public static GameObject GenerateRandomCharacterData( GameObject characterPrefab, Transform parent )
		{
			GameObject result = Object.Instantiate( characterPrefab, parent );

			CharacterBase rand = result.GetComponent<CharacterBase>();
			rand.characterData = new CharacterData();
			rand.characterData.SetBodyMap( Random.Range( 10, 30 ), Random.Range( 20, 30 ) );
			rand.characterData.GenerateRandomMapData();

			Debug.Log( "size:" + rand.characterData.bodyMap.GetLength( 0 ) + "," + rand.characterData.bodyMap.GetLength( 1 ) );

			return result;
		}

		public static GameObject GenerateCharacterDataByConfig( GameObject characterPrefab, Transform parent, CharacterConfig config )
		{
			GameObject result = Object.Instantiate( characterPrefab, parent );

			//TODO : generate by config

			return result;
		}
	}
}

