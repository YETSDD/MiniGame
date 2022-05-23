using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{


	public BehaviourControllerBase currentController;

	private void ShowCharater( CharacterControllerBase source )
	{
		CharacterDisplay playerCharacterDisplay = source.characterDisplay;
		playerCharacterDisplay.InitializeMap( source.character, source.transform );
		playerCharacterDisplay.UpdateMap( source.character );
	}
}


