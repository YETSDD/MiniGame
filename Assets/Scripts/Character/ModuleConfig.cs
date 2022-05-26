using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "module", menuName = "Character/Module" )]
public class ModuleConfig : ScriptableObject
{
	public string moduleName;

	public List<PixelData> ownPixels = new List<PixelData>();

	public SkillSet defaultSkillSet;

	public List<SkillSet> skillSetPool;
}