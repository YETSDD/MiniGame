using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( CharacterBuilder ) )]
public class CharacterBuilderEditor : Editor
{
	public override void OnInspectorGUI()
	{

		base.OnInspectorGUI();

		CharacterBuilder characterBuilder = (CharacterBuilder)target;

		if( GUILayout.Button( "LoadDataFromConfig" ) )
		{
			characterBuilder.LoadDataFromConfig();
		}

		if( GUILayout.Button( "InitializeConfig" ) )
		{
			characterBuilder.InitializeConfig();
		}

		if( GUILayout.Button( "BindSelectedPixel" ) )
		{
			characterBuilder.BindPixelToModule();
		}

		if( GUILayout.Button( "SelectBindedPixelOfModule" ) )
		{
			characterBuilder.ShowBindedPixelOfModule( characterBuilder.currentModule );
		}

		if( GUILayout.Button( "Clear" ) )
		{
			characterBuilder.ClearCache();
		}
	}
}
