using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( SkillEffectTest ) )]
public class SkillEffectTestEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SkillEffectTest skill = (SkillEffectTest)target;
		if( GUILayout.Button( "Damage" ) )
		{
			skill.DealRectDamageToCharacter( skill.targetCharacter, skill.basicDamageAmount );
		}
	}


}
