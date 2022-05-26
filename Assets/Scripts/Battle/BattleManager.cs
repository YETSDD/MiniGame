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

	public void ResetBattle()
	{
		CharacterManager.instance.RemoveMonster();
		if( monsterController )
		{
			Destroy( monsterController );
		}
		CharacterManager.instance.RemovePlayer();
		if( playerController )
		{
			Destroy( playerController );
		}
		currentController = null;
	}

	public void InitializePlayerController()
	{
		if( playerController == null )
		{
			playerController = this.gameObject.AddComponent<PlayerController>();
			playerController.self = CharacterManager.instance.player;
		}
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
		monsterController.self = CharacterManager.instance.monster;
		monsterController.target = CharacterManager.instance.player;
	}

	public void StartBattle()
	{
		currentController = playerController;
		currentController.TransisteState( CharacterStateType.Prepare );
	}

	public void SetPlayerSkillToRelease( SkillBase skill )
	{
		playerController.skillToRelease = skill;
	}

	public void SwitchController()
	{
		if( JudgeIfBattleOver() )
		{
			return;
		}

		if( currentController == playerController )
		{
			currentController = monsterController;
			Debug.Log( "Switch to monster" );
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

	public bool JudgeIfBattleOver()
	{
		if( !CharacterManager.instance.player.isAlive )
		{
			GameManager.instance.PlayerDie();
			return true;
		}
		if( !CharacterManager.instance.monster.isAlive )
		{
			GameManager.instance.MonsterDie();
			return true;
		}
		return false;
	}

	public void Win()
	{
		CharacterManager.instance.RemoveMonster();
		Destroy( monsterController );
		playerController.currentState = playerController.states[CharacterStateType.Wait];
		if( !BattlePanel.instance.FinishLevel() )
		{
			SelectPanel.instance.BetweenBattle();
		}
	}
}


