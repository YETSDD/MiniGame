using System.Collections;
using System.Collections.Generic;
using System.Text;
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

		StringBuilder name = new StringBuilder();
		foreach( Module module in monster.character.modules )
		{
			name.Append( module.skillSet.shownName );
		}
		name.Append( " ֮" );
		name.Append( config.characterName );
		BattlePanel.instance.enemyName.text = name.ToString();
	}

	public void RemovePlayer()
	{
		if( player )
		{
			Destroy( player.gameObject );
		}
	}

	public void RemoveMonster()
	{
		if( monster )
		{
			Destroy( monster.gameObject );
		}
	}

	public void BattleFinish()
	{
		if( player )
		{
			RemovePlayer();
		}
		if( monster )
		{
			RemoveMonster();
		}
	}
}
