using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public static CharacterManager instance;

	public CharacterConfig playerCharacterConfig;

	public CharacterControllerBase characterPrefab;

	public CharacterControllerBase player;

	public CharacterControllerBase monster;

	public Transform playerParent;

	public Transform monsterParent;

	private void Awake()
	{
		instance = this;
	}

	public void GeneratePlayer()
	{
		player = Utility.Generator.GeneratePlayer( characterPrefab, playerParent, playerCharacterConfig );
		CharacterDisplay playerCharacterDisplay = player.characterDisplay;
		playerCharacterDisplay.InitializeMap( player.character, player.transform );
		playerCharacterDisplay.UpdateMap( player.character );
	}

	public void GenenrateMonster( CharacterConfig config )
	{
		monster = Utility.Generator.GenerateMonster( characterPrefab, monsterParent, config );
		CharacterDisplay monsterCharacterDisplay = monster.characterDisplay;
		monsterCharacterDisplay.InitializeMap( monster.character, monster.transform );
		monsterCharacterDisplay.UpdateMap( monster.character );
	}
}
