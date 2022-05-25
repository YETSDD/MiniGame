using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "level", menuName = "Level/Level" )]
public class Level : ScriptableObject, ISerializationCallbackReceiver
{
	public List<(CharacterConfig, AIType)> monsters = new List<(CharacterConfig, AIType)>();

	[SerializeField]
	private List<CharacterConfig> _configs = new List<CharacterConfig>();

	[SerializeField]
	private List<AIType> _controllers = new List<AIType>();



	public void OnAfterDeserialize()
	{
		monsters.Clear();
		for( int i = 0; i < Mathf.Min( _configs.Count, _controllers.Count ); i++ )
		{
			monsters.Add( (_configs[i], _controllers[i]) );
		}

	}

	public void OnBeforeSerialize()
	{
		_configs.Clear();
		_controllers.Clear();

		foreach( (CharacterConfig, AIType) pair in monsters )
		{
			_configs.Add( pair.Item1 );
			_controllers.Add( pair.Item2 );
		}
	}
}
