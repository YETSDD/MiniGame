using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModuleSkillMap : ISerializationCallbackReceiver
{
	[SerializeField]
	private List<ModuleConfig> _configs = new List<ModuleConfig>();

	[SerializeField]
	private List<SkillSet> _skillSets = new List<SkillSet>();

	public Dictionary<ModuleConfig, SkillSet> moduleSkillMap = new Dictionary<ModuleConfig, SkillSet>();

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
		_configs.Clear();
		_skillSets.Clear();

		foreach( KeyValuePair<ModuleConfig, SkillSet> pair in moduleSkillMap )
		{
			_configs.Add( pair.Key );
			_skillSets.Add( pair.Value );
		}
	}

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
		moduleSkillMap.Clear();

		for( int i = 0; i < Mathf.Min( _configs.Count, _skillSets.Count ); i++ )
		{
			moduleSkillMap.Add( _configs[i], _skillSets[i] );
		}
	}


}
