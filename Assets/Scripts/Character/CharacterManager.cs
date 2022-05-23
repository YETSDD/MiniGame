using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public static CharacterManager instance;

	public CharacterConfig playerCharacterConfig;

	public CharacterControllerBase characterPrefab;

	public CharacterControllerBase player;

	public CharacterControllerBase monster;

	private void Awake()
	{
		instance = this;
	}

	public void GeneratePlayer()
	{
		player = Utility.Generator.GeneratePlayer( characterPrefab, this.transform, playerCharacterConfig );
	}

	public void GenenrateMonster()
	{
		//TODO: Generate by level
	}
}
