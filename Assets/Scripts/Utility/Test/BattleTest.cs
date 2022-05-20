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

	public BehaviourControllerBase leftBehaviourController;

	public BehaviourControllerBase rightBehaviourController;

	public BehaviourControllerBase currentController;

	public const float interval = 1.0f;

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

		leftBehaviourController = leftCharacter.gameObject.AddComponent<AIController>();
		AIController left = leftCharacter.gameObject.GetComponent<AIController>();
		left.self = leftCharacter;
		left.target = rightCharacter;

		rightBehaviourController = rightCharacter.gameObject.AddComponent<AIController>();
		AIController right = rightCharacter.gameObject.GetComponent<AIController>();
		right.self = rightCharacter;
		right.target = leftCharacter;

		RoundLoop();
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

	private void RoundLoop()
	{
		currentController = leftBehaviourController;

		//TODO: Loop Coroutine

	}

	public IEnumerator Loop()
	{
		yield return new WaitForSeconds( interval );
	}

	private void SwitchController()
	{
		if( currentController == leftBehaviourController )
		{
			currentController = rightBehaviourController;
		}
		else if( currentController == rightBehaviourController )
		{
			currentController = leftBehaviourController;
		}
		else
		{
			throw new System.Exception( "Currnet Controller Not Selected" );
		}
	}

	public void BattleEnd()
	{

	}


}
