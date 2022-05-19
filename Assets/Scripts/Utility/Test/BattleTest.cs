using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTest : MonoBehaviour
{
	public static BattleTest instance;

	public CharacterControllerBase leftCharacter;

	public CharacterControllerBase rightCharacter;

	public CharacterConfig leftCharacterConfig;

	public CharacterConfig rightCharacterConfig;

	public CharacterControllerBase characterPrefab;

	public Transform leftCharacterTransform;

	public Transform rightCharacterTransform;

	private void Awake()
	{
		instance = this;
	}

	public void StartBattle()
	{
		leftCharacter = GenerateCharater( leftCharacterConfig, leftCharacterTransform );
		rightCharacter = GenerateCharater( rightCharacterConfig, rightCharacterTransform );
		ShowCharater( leftCharacter );
		ShowCharater( rightCharacter );
	}

	private CharacterControllerBase GenerateCharater( CharacterConfig config, Transform transform )
	{

		CharacterControllerBase result = Instantiate( characterPrefab, transform );
		Character character = new Character();
		character.InitializeByConfig( config );
		result.character = character;

		return result;
	}

	private void ShowCharater( CharacterControllerBase src )
	{
		CharacterDisplay playerCharacterDisplay = src.characterDisplay;
		playerCharacterDisplay.InitializeMap( src.character, src.transform );
		playerCharacterDisplay.UpdateMap( src.character );
	}
	public void BattleEnd()
	{

	}


}
