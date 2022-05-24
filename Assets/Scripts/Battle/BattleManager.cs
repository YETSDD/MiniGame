using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	public static BattleManager instance;

	public BehaviourControllerBase currentController;

	public BehaviourControllerBase playerController;

	public BehaviourControllerBase monsterController;

	private void Awake()
	{
		instance = this;
	}

	public void InitializePlayerController()
	{
		playerController = this.gameObject.AddComponent<PlayerController>();
	}

	private void ShowCharater( CharacterControllerBase source )
	{
		CharacterDisplay playerCharacterDisplay = source.characterDisplay;
		playerCharacterDisplay.InitializeMap( source.character, source.transform );
		playerCharacterDisplay.UpdateMap( source.character );
	}
}


