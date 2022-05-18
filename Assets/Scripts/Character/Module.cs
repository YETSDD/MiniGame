using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Module
{
	public ModuleConfig config;

	public List<BuffBase> buffs;

	public ModificationBase modification;

	public List<ActionBase> availableActions = new List<ActionBase>();

	public List<ActionBase> unavailableActions = new List<ActionBase>();

	public Module( ModuleConfig config, ModificationBase modification = null )
	{
		this.config = config;
		this.modification = modification;
		EvaluateAvailableActions();
	}

	public void EvaluateAvailableActions()
	{
		if( modification != null )
		{
			foreach( ActionBase action in modification.ownActions )
			{
				if( JudgeIfActive( action ) )
				{
					availableActions.Add( action );
				}
				else
				{
					unavailableActions.Add( action );
				}
			}
		}
	}

	public bool JudgeIfActive( ActionBase action )
	{
		//TODO: evaluate active pixels and total healthpoint percentage of this module
		return true;
	}
}
