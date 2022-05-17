using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject characterPrefab;

    public GameObject playerCharacterObject;

    public void UpdateCharacterMap(GameObject target)
    {
        CharacterBase characterBase = target.GetComponent<CharacterBase>();
        CharacterDisplay characterDisplay;
        if (target.TryGetComponent<CharacterDisplay>(out characterDisplay))
        {
            characterDisplay.UpdateMap(characterBase.characterData);
        }
    }
}
