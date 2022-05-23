using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
	public BehaviourControllerBase behaviourController;

	public CharacterState( BehaviourControllerBase controller )
	{
		behaviourController = controller;
	}

	public virtual void OnEnter()
	{
	}

	public virtual void OnUpdate()
	{
	}

	public virtual void OnExit()
	{
	}
}

public enum CharacterStateType
{
	Prepare,
	Act,
	Settle,
	Wait
}

public class PrepareState : CharacterState
{
	public PrepareState( BehaviourControllerBase controller ) : base( controller )
	{
	}

	public override void OnEnter()
	{
		base.OnEnter();
		behaviourController.OnTurn();
		behaviourController.Prepare();
		behaviourController.self.OnRoundPrepare();
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		behaviourController.TransisteState( CharacterStateType.Act );
	}

	public override void OnExit()
	{
		base.OnExit();
	}
}

public class ActState : CharacterState
{
	public ActState( BehaviourControllerBase controller ) : base( controller )
	{
	}

	public override void OnEnter()
	{
		base.OnEnter();
		behaviourController.Act();
		behaviourController.self.OnRoundAct();
	}

	public override void OnUpdate()
	{//TODO: Animation
		base.OnUpdate();
		behaviourController.TransisteState( CharacterStateType.Settle );
	}

	public override void OnExit()
	{
		base.OnExit();
	}
}

public class SettleState : CharacterState
{
	public SettleState( BehaviourControllerBase controller ) : base( controller )
	{
	}

	public override void OnEnter()
	{
		base.OnEnter();
		behaviourController.Settle();
		behaviourController.self.OnRoundSettle();
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		behaviourController.TransisteState( CharacterStateType.Wait );
	}

	public override void OnExit()
	{
		base.OnExit();
	}
}

public class WaitState : CharacterState
{
	public WaitState( BehaviourControllerBase controller ) : base( controller )
	{
	}

	public override void OnEnter()
	{
		base.OnEnter();
		behaviourController.RoundOver();
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
	}

	public override void OnExit()
	{
		base.OnExit();
	}
}