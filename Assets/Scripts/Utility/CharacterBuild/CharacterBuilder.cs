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

	public GameObject pixelPrefab;

	public ModuleConfig currentModule;

	public GameObject[] selectedGameObjects;

	public List<ModuleConfig> modules = new List<ModuleConfig>();

	public List<GameObject> gameObjectsOfPixel = new List<GameObject>();

	//场景中的GameObject 与 所选取的CharacterConfig的PixelData 之间的映射关系
	private Dictionary<GameObject, PixelData> _mapBetweenGameObjectAndPixelData = new Dictionary<GameObject, PixelData>();

	public void LoadDataFromConfig()
	{
		if( characterConfig != null )
		{
			if( characterConfig.isInitialized )
			{
				width = characterConfig.width;
				height = characterConfig.height;
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
		int width = characterConfig.width;
		int height = characterConfig.height;
		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				GameObject gameObject = Instantiate( pixelPrefab, new Vector3( x * pixelWidth, y * pixelHeight, 0 ), Quaternion.identity, transform );
				gameObject.GetComponent<PixelObject>().pixelData.LoadPixelData( characterConfig.bodyMap[x, y] );
				gameObjectsOfPixel.Add( gameObject );
				_mapBetweenGameObjectAndPixelData.Add( gameObject, characterConfig.bodyMap[x, y] );
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
		if( currentModule == null )
		{
			throw new System.Exception( "currentModule Not Selected" );
		}
		selectedGameObjects = Selection.gameObjects;
		currentModule.ownPixels.Clear();
		for( int i = 0; i < selectedGameObjects.Length; i++ )
		{
			selectedGameObjects[i].GetComponent<PixelObject>().pixelData.moduleRef = currentModule;

			currentModule.ownPixels.Add( _mapBetweenGameObjectAndPixelData[selectedGameObjects[i]] );
		}
	}

	public void ShowBindedPixelOfModule( ModuleConfig module )
	{
		List<GameObject> objectsToBeSelected = new List<GameObject>();
		for( int i = 0; i < gameObjectsOfPixel.Count; i++ )
		{
			if( _mapBetweenGameObjectAndPixelData[gameObjectsOfPixel[i]].moduleRef == module )
			{
				objectsToBeSelected.Add( gameObjectsOfPixel[i] );
			}
		}
		Selection.objects = objectsToBeSelected.ToArray();
	}

	public void SaveConfig()
	{
		foreach( GameObject gameObject in gameObjectsOfPixel )
		{
			PixelData pixelData = gameObject.GetComponent<PixelObject>().pixelData;
			_mapBetweenGameObjectAndPixelData[gameObject].LoadPixelData( pixelData );
		}
	}

	public void ClearCache()
	{
		_mapBetweenGameObjectAndPixelData.Clear();
		while( gameObjectsOfPixel.Count > 0 )
		{
			GameObject gameObject = gameObjectsOfPixel[gameObjectsOfPixel.Count - 1];
			gameObjectsOfPixel.RemoveAt( gameObjectsOfPixel.Count - 1 );
			Destroy( gameObject );
		}
		gameObjectsOfPixel.Clear();
	}
}
