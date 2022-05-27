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

	public const float minAlivePixelPercentage = 0.2f;

	public bool isAlive = true;

	private void Awake()
	{
		OnCharacterDataChanged = UpdateDisplay;
		OnCharacterDataChanged += UpdateAvailableSkills;
		OnCharacterDataChanged += UpdateAliveState;
		characterDisplay = GetComponent<CharacterDisplay>();
	}

	private void OnDestroy()
	{
		OnCharacterDataChanged -= UpdateDisplay;
		OnCharacterDataChanged -= UpdateAvailableSkills;
		OnCharacterDataChanged -= UpdateAliveState;
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

	public float ChangeHealthPoint( float[,] healthPointChangeMap )
	{
		float totalHealthPointChange = 0;
		if( character == null )
		{
			return 0;
		}

		if( healthPointChangeMap.GetLength( 0 ) != character.bodyMap.GetLength( 0 ) || healthPointChangeMap.GetLength( 1 ) != character.bodyMap.GetLength( 1 ) )
		{
			return 0;
		}

		for( int i = 0; i < healthPointChangeMap.GetLength( 0 ); i++ )
		{
			for( int j = 0; j < healthPointChangeMap.GetLength( 1 ); j++ )
			{
				totalHealthPointChange += character.bodyMap[i, j].ChangeHealthPoint( healthPointChangeMap[i, j] );
			}
		}
		OnCharacterDataChanged.Invoke();

		return totalHealthPointChange;
	}

	public void UpdateAvailableSkills()
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

	public void UpdateAliveState()
	{
		isAlive = JudgeIfAlive();
	}

	public bool JudgeIfAlive()
	{
		int alivePixelCount = 0;
		int deadPixelCount = 0;
		foreach( PixelData pixel in character.bodyMap )
		{
			if( pixel.moduleRef == null )
			{
				continue;
			}

			if( pixel.currentHealthPoint > 0 )
			{
				alivePixelCount++;
			}
			else
			{
				deadPixelCount++;
			}
		}
		if( alivePixelCount == 0 && deadPixelCount == 0 )
		{
			return false;
		}
		float alivePercentage = (float)alivePixelCount / (float)( alivePixelCount + deadPixelCount );
		return alivePercentage >= minAlivePixelPercentage;
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
