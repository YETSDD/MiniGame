using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	public static BattleManager instance;

	public BehaviourControllerBase currentController;

	public PlayerController playerController;

	public BasicAIController monsterController;



	private void Awake()
	{
		instance = this;
	}

	public void InitializePlayerController()
	{
		playerController = this.gameObject.AddComponent<PlayerController>();
	}

	public void InitializeAIController( AIType type )
	{
		switch( type )
		{
			case AIType.Basic:
				monsterController = this.gameObject.AddComponent<BasicAIController>();
				break;
			case AIType.Slime:
				monsterController = this.gameObject.AddComponent<SlimeController>();
				break;
			default:
				break;
		}
	}

	public void StartBattle()
	{

	}

	public void SetPlayerSkillToRelease( SkillBase skill )
	{
		playerController.skillToRelease = skill;
	}

	public void SwitchController()
	{
		if( currentController == playerController )
		{
			currentController = monsterController;
			currentController.TransisteState( CharacterStateType.Prepare );
		}
		else if( currentController == monsterController )
		{
			currentController = playerController;
			currentController.TransisteState( CharacterStateType.Prepare );
		}
		else
		{
			throw new System.Exception( "Currnet Controller Not Selected" );
		}
	}
}


