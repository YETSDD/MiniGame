using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterBuilder : MonoBehaviour
{
	public int width, height;

	public const float pixelWidth = 1.1f;

	public const float pixelHeight = 1.1f;

	public CharacterConfig characterConfig;

	public List<ModuleConfig> modules = new List<ModuleConfig>();

	public GameObject pixelPrefab;

	public List<GameObject> gameObjectsOfPixel = new List<GameObject>();

	public ModuleConfig currentModule;

	public GameObject[] selectedGameObjects;

	private Dictionary<GameObject, PixelData> _pixelsMap = new Dictionary<GameObject, PixelData>();

	public void LoadDataFromConfig()
	{
		if( characterConfig != null )
		{
			if( characterConfig.isInitialized() )
			{
				width = characterConfig.bodyMap.GetLength( 0 );
				height = characterConfig.bodyMap.GetLength( 1 );
				modules = new List<ModuleConfig>( characterConfig.modules );
				ShowPixelsInScene();
			}
			else
			{
				Debug.Log( "Not Initialized" );
			}
		}
	}

	public void ShowPixelsInScene()
	{
		PixelData[,] pixelDatas = characterConfig.bodyMap;
		for( int i = 0; i < pixelDatas.GetLength( 0 ); i++ )
		{
			for( int j = 0; j < pixelDatas.GetLength( 1 ); j++ )
			{
				GameObject gameObject = Instantiate( pixelPrefab, new Vector3( i * pixelWidth, j * pixelHeight, 0 ), Quaternion.identity, transform );
				gameObjectsOfPixel.Add( gameObject );
				_pixelsMap.Add( gameObject, pixelDatas[i, j] );
			}
		}
	}

	public void InitializeConfig()
	{
		if( modules == null )
		{
			characterConfig.modules = modules;
		}
		characterConfig.SetBodyMap( width, height );

	}

	public void BindPixelToModule()
	{
		selectedGameObjects = Selection.gameObjects;
		for( int i = 0; i < selectedGameObjects.Length; i++ )
		{
			PixelData pixelData = _pixelsMap[selectedGameObjects[i]];
			pixelData.moduleRef = currentModule;

			selectedGameObjects[i].GetComponent<PixelObject>().pixelData.moduleRef = currentModule;
		}
	}

	public void ShowBindedPixelOfModule( ModuleConfig module )
	{

		for( int i = 0; i < gameObjectsOfPixel.Count; i++ )
		{
			if( _pixelsMap[gameObjectsOfPixel[i]].moduleRef == module )
			{
				Selection.activeGameObject = gameObjectsOfPixel[i];
			}
		}
	}

	public void ClearCache()
	{
		_pixelsMap = null;
		while( gameObjectsOfPixel.Count > 0 )
		{
			GameObject gameObject = gameObjectsOfPixel[gameObjectsOfPixel.Count - 1];
			gameObjectsOfPixel.RemoveAt( gameObjectsOfPixel.Count - 1 );
			Destroy( gameObject );
		}
		gameObjectsOfPixel = null;
	}
}
