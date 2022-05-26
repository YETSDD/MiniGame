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

	public List<ModuleConfig> modules = new List<ModuleConfig>();

	public List<GameObject> gameObjectsOfPixel = new List<GameObject>();

	//�����е�GameObject �� ��ѡȡ��CharacterConfig��PixelData ֮���ӳ���ϵ
	private Dictionary<GameObject, PixelData> _mapBetweenGameObjectAndPixelData = new Dictionary<GameObject, PixelData>();

	public void LoadDataFromConfig()
	{

		gameObjectsOfPixel = new List<GameObject>();
		_mapBetweenGameObjectAndPixelData = new Dictionary<GameObject, PixelData>();
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
			throw new System.Exception( "CurrentModule Not Selected" );
		}

		GameObject[] selectedGameObjects = Selection.gameObjects;
		currentModule.ownPixels.Clear();

		for( int i = 0; i < selectedGameObjects.Length; i++ )
		{
			selectedGameObjects[i].GetComponent<PixelObject>().pixelData.moduleRef = currentModule;

			PixelData pixel = _mapBetweenGameObjectAndPixelData[selectedGameObjects[i]];
			currentModule.ownPixels.Add( pixel );
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
		for( int i = 0; i < gameObjectsOfPixel.Count; i++ )
		{
			GameObject gameObject = gameObjectsOfPixel[i];
			PixelData pixelData = gameObject.GetComponent<PixelObject>().pixelData;
			if( pixelData.moduleRef == null )
			{
				pixelData.currentHealthPoint = 0;
			}
			_mapBetweenGameObjectAndPixelData[gameObject].LoadPixelData( pixelData );
		}
		EditorUtility.SetDirty( characterConfig );
	}

	public void ClearCache()
	{
		//_mapBetweenGameObjectAndPixelData.Clear();

		for( int i = _mapBetweenGameObjectAndPixelData.Count; i > 0; i-- )
		{
			_mapBetweenGameObjectAndPixelData.Remove( gameObjectsOfPixel[i - 1] );
		}

		while( gameObjectsOfPixel.Count > 0 )
		{
			GameObject gameObject = gameObjectsOfPixel[gameObjectsOfPixel.Count - 1];
			gameObjectsOfPixel.RemoveAt( gameObjectsOfPixel.Count - 1 );
			Destroy( gameObject );
		}
		gameObjectsOfPixel.Clear();
	}
}
