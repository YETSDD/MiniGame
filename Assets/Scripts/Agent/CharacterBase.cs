using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterDisplay ) )]
public class CharacterBase : MonoBehaviour
{
	public CharacterData characterData;

	public CharacterDisplay characterDisplay;

	public delegate void CharacterDelegate( CharacterData characterData );

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
		ModuleData[] modules = characterData.modules;
		for( int i = 0; i < modules.Length; i++ )
		{
			HandleBuff( modules[i], stage );
		}
	}

	private void HandleBuff( ModuleData module, RoundStage stage )
	{
	}
	public void ChangeHealthPoint( float[,] healthPointChangeMap )
	{
		if( characterData == null )
		{
			return;
		}

		if( healthPointChangeMap.GetLength( 0 ) != characterData.bodyMap.GetLength( 0 ) || healthPointChangeMap.GetLength( 1 ) != characterData.bodyMap.GetLength( 1 ) )
		{
			return;
		}

		for( int i = 0; i < healthPointChangeMap.GetLength( 0 ); i++ )
		{
			for( int j = 0; j < healthPointChangeMap.GetLength( 1 ); j++ )
			{
				characterData.bodyMap[i, j].ChangeHealthPoint( healthPointChangeMap[i, j] );

				OnCharacterDataChanged.Invoke( characterData );
			}
		}
	}

	#endregion

	#region View

	public void UpdateDisplay( CharacterData data )
	{
		if( characterDisplay != null )
		{
			characterDisplay.UpdateMap( data );
		}
	}

	#endregion
}
