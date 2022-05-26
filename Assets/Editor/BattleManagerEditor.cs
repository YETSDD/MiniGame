using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor( typeof( BattleManager ) )]
public class BattleManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		BattleManager battleManager = (BattleManager)target;

		if( GUILayout.Button( "Win" ) )
		{
			CharacterManager.instance.monster.isAlive = false;
			GameManager.instance.MonsterDie();
		}

		if( GUILayout.Button( "Lose" ) ) {
			CharacterManager.instance.player.isAlive = false;
			GameManager.instance.PlayerDie();
		}
	}
}
