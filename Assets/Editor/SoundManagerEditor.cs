using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor( typeof( SoundManager ) )]
public class SoundManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SoundManager manager = (SoundManager)target;

		if( GUILayout.Button( "Load" ) )
		{
			AkBankManager.LoadBank( "New_SoundBank", true, true );

		}

		if( GUILayout.Button( "Impact" ) )
		{
			AkSoundEngine.PostEvent( "PlayImpact", manager.gameObject);
		}

	}
}
