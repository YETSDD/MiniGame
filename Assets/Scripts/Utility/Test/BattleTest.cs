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

		BasicAIController left = leftCharacter.gameObject.AddComponent<BasicAIController>();
		leftBehaviourController = left;
		left.self = leftCharacter;
		left.target = rightCharacter;

		BasicAIController right = rightCharacter.gameObject.AddComponent<BasicAIController>();
		rightBehaviourController = right;
		right.self = rightCharacter;
		right.target = leftCharacter;

		RoundLoop();
	}


	private CharacterControllerBase GenerateCharater( CharacterConfig config, Transform transform )
	{
		CharacterControllerBase result = Instantiate( characterPrefab, transform );
		Character character = new Character( config );
		result.character = character;

		return result;
	}

	private void ShowCharater( CharacterControllerBase source )
	{
		CharacterDisplay playerCharacterDisplay = source.characterDisplay;
		playerCharacterDisplay.InitializeMap( source.character, source.transform );
		playerCharacterDisplay.UpdateMap( source.character );
	}

	private void RoundLoop()
	{
		currentController = leftBehaviourController;
		currentController.TransisteState( CharacterStateType.Prepare );

	}

	public IEnumerator Loop()
	{
		yield return new WaitForSeconds( interval );

		currentController.TransisteState( CharacterStateType.Prepare );
		SwitchController();
		StartCoroutine( Loop() );
	}

	public void SwitchController()
	{
		if( currentController == leftBehaviourController )
		{
			currentController = rightBehaviourController;
			currentController.TransisteState( CharacterStateType.Prepare );
		}
		else if( currentController == rightBehaviourController )
		{
			currentController = leftBehaviourController;
			currentController.TransisteState( CharacterStateType.Prepare );
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
