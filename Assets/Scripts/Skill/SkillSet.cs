using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "SkillSet", menuName = "Character/SkillSet" )]
public class SkillSet : ScriptableObject
{
	public string shownName;

	public List<SkillBase> ownSkills = new List<SkillBase>();
}
