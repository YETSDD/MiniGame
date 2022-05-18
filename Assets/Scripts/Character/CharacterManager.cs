using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
#if UNITY_EDITOR
	public CharacterConfig playerCharacterConfig;
#endif

	public CharacterControllerBase characterPrefab;

	public CharacterControllerBase playerCharacter;

}
