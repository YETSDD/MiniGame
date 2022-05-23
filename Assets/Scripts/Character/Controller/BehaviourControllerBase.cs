using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourControllerBase : MonoBehaviour
{
	public CharacterControllerBase self;

	public CharacterState currentState;

	public Dictionary<CharacterStateType, CharacterState> states = new Dictionary<CharacterStateType, CharacterState>();

	private void Awake()
	{
		states.Add( CharacterStateType.Prepare, new PrepareState( this ) );
		states.Add( CharacterStateType.Act, new ActState( this ) );
		states.Add( CharacterStateType.End, new EndState( this ) );
		states.Add( CharacterStateType.Wait, new WaitState( this ) );
		currentState = states[CharacterStateType.Wait];
	}

	private void Update()
	{
		UpdateState();
	}

	public virtual void OnTurn()
	{
		if( self == null )
		{
			throw new System.Exception( "Self Not Initialized" );
		}
	}

	public virtual void Prepare()
	{
	}


	public virtual void Act()
	{
	}

	public virtual void End()
	{
		Debug.Log( "������һЩ���⶯��" );
	}

	public void TransisteState( CharacterStateType state )
	{
		if( currentState == null )
		{
			throw new System.Exception( "Character State Not Initialized" );
		}

		CharacterState nextState = states[state];
		if( currentState.GetType() == nextState.GetType() )
		{
			return;
		}

		currentState.OnExit();
		currentState = nextState;
		currentState.OnEnter();
	}

	public void UpdateState()
	{
		if( currentState == null )
		{
			throw new System.Exception( "Character State Not Initialized" );
		}
		currentState.OnUpdate();
	}

	public void RoundOver()
	{//TODO: BattleManager
		BattleTest.instance.SwitchController();
	}
}
