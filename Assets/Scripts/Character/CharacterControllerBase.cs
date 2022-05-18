using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterDisplay ) )]
public class CharacterControllerBase : MonoBehaviour
{
	public Character character;

	public CharacterDisplay characterDisplay;

	public delegate void CharacterDelegate( Character characterData );

	public CharacterDelegate OnCharacterDataChanged;

	private void Awake()
	{
		OnCharacterDataChanged = UpdateDisplay;
		characterDisplay = GetComponent<CharacterDisplay>();
	}

	#region Logic Controller

	public void OnRoundPrepare()
	{
		HandleBuffs( RoundStage.Prepare );
	}

	public void OnRoundAct()
	{
		HandleBuffs( RoundStage.Act );
	}

	public void OnRoundSettle()
	{
		HandleBuffs( RoundStage.Settle );
	}

	private void HandleBuffs( RoundStage stage )
	{
		Module[] modules = character.modules;
		for( int i = 0; i < modules.Length; i++ )
		{
			HandleBuff( modules[i], stage );
		}
	}

	private void HandleBuff( Module module, RoundStage stage )
	{
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

				OnCharacterDataChanged.Invoke( character );
			}
		}
	}

	#endregion

	#region View

	public void UpdateDisplay( Character data )
	{
		if( characterDisplay != null )
		{
			characterDisplay.UpdateMap( data );
		}
	}

	#endregion
}
