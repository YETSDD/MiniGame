using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BehaviourControllerBase
{
	public PlayerController instance;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
	}

	private void Start()
	{

	}


}
