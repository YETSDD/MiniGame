using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BehaviourControllerBase
{
    public PlayerController instance;

	public CharacterConfig defaultPlayerConfig;

	public CharacterController self;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		
	}


}
