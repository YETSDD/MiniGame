using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BehaviourControllerBase
{
	public PlayerController instance;

	public SkillBase skillToRelease;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
	}
	public override void OnTurn()
	{
		if( self == null )
		{
			throw new System.Exception( "Player Controller Not Initialized" );
		}
	}

	public override void Prepare()
	{
		Debug.Log( "Prepare" );
	}

	public override void Act()
	{
		Debug.Log( "Act" );
	}

	public override void End()
	{
		Debug.Log( "End" );
	}
}
