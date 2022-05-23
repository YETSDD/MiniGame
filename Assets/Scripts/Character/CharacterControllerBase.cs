using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent( typeof( CharacterDisplay ) )]
public class CharacterControllerBase : MonoBehaviour
{
	public Character character;

	public CharacterDisplay characterDisplay;

	public delegate void CharacterDelegate();

	public CharacterDelegate OnCharacterDataChanged;

	private void Awake()
	{
		OnCharacterDataChanged = UpdateDisplay;
		OnCharacterDataChanged += UpdateAvailableSkills;
		characterDisplay = GetComponent<CharacterDisplay>();
	}

	#region Logic Controller

	public void OnRoundPrepare()
	{
		HandleBuffs( CharacterStateType.Prepare );
	}

	public void OnRoundAct()
	{
		HandleBuffs( CharacterStateType.Act );
	}

	public void OnRoundEnd()
	{
		HandleBuffs( CharacterStateType.End );
	}

	private void HandleBuffs( CharacterStateType stage )
	{
		//TODO: handle global buff
		Module[] modules = character.modules;
		for( int i = 0; i < modules.Length; i++ )
		{
			HandleBuff( modules[i], stage );
		}
	}

	private void HandleBuff( Module module, CharacterStateType stage )
	{
		//TODO: handle part buff
	}

	public void ChangeHealthPoint( float[,] healthPointChangeMap )
	{
		if( character == null )
		{
			return;
		}

		if( healthPointChangeMap.GetLength( 0 ) != character.bodyMap.GetLength( 0 ) || healthPointChangeMap.GetLength( 1 ) != character.bodyMap.GetLength( 1 ) )
		{
			return;
		}

		for( int i = 0; i < healthPointChangeMap.GetLength( 0 ); i++ )
		{
			for( int j = 0; j < healthPointChangeMap.GetLength( 1 ); j++ )
			{
				character.bodyMap[i, j].ChangeHealthPoint( healthPointChangeMap[i, j] );
			}
		}
		OnCharacterDataChanged.Invoke();
	}

	private void UpdateAvailableSkills()
	{
		List<SkillBase> availableSkills = character.allAvailableSkills;
		availableSkills.Clear();

		if( character.basicSkill != null )
		{
			availableSkills.Add( character.basicSkill );
		}

		foreach( Module module in character.modules )
		{
			availableSkills.AddRange( module.availableSkills );
		}
	}



	#endregion

	#region View

	public void UpdateDisplay()
	{
		if( characterDisplay == null )
		{
			throw new System.Exception( "Null CharacterDisplay" );
		}

		characterDisplay.UpdateMap( character );
	}

	#endregion
}
