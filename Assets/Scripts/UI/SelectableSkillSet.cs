using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class SelectableSkillSet : MonoBehaviour
{
	public TextMeshProUGUI module;

	public TextMeshProUGUI skillSet;

	public SkillPresentation skillPrefab;

	public Transform skillRoot;

	public void Set( string moduleName, string skillSetName, List<SkillBase> skills )
	{
		module.text = moduleName;
		skillSet.text = skillSetName;

		skillRoot.DestroyAllChilds();
		foreach( SkillBase skill in skills )
		{
			SkillPresentation skillPresentation = Instantiate( skillPrefab, skillRoot );
			skillPresentation.Set( skill.shownName, skill.image );
		}
	}
}
