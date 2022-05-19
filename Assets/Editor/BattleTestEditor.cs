using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor( typeof( BattleTest ) )]
public class BattleTestEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		BattleTest battleTest = (BattleTest)target;

		if( GUILayout.Button( "StartBattle" ) )
		{
			battleTest.StartBattle();
		}

	}
}
