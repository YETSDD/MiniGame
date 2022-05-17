using UnityEngine;



public class CharacterDisplay : MonoBehaviour
{
	public DisplayMode displayMode = DisplayMode.ElementColor;

	public GameObject gridPrefab;

	public const float gridLength = 1.1f;

	public const float gridWidth = 1.1f;

	private GridData[,] _grids;

	public void InitializeMap( CharacterData src, Transform root, DisplayMode mode = DisplayMode.ElementColor )
	{
		PixelData[,] map = src.bodyMap;
		_grids = new GridData[src.bodyMap.GetLength( 0 ), src.bodyMap.GetLength( 1 )];

		for( int i = 0; i < map.GetLength( 0 ); i++ )
		{
			for( int j = 0; j < map.GetLength( 1 ); j++ )
			{
				GameObject obj = Instantiate( gridPrefab, new Vector3( i * gridWidth, j * gridLength, 0 ), Quaternion.identity, root );

				_grids[i, j] = obj.GetComponent<GridData>();
			}
		}
	}

	private Color GetPixelColor( float healthPoint, DisplayMode mode )
	{
		float colorVal = Mathf.Lerp( 0, 1, healthPoint / 100.0f );
		Color color;
		switch( mode )
		{
			case DisplayMode.BlackAndWhite:
				color = Color.HSVToRGB( 0, 1, Mathf.Lerp( 0, 1, colorVal ) );
				break;
			case DisplayMode.ElementColor://TODO: Different Element Color 
				color = new Color( colorVal, 0, 0, 1 );
				break;
			default:
				color = new Color( 1, 1, 1 );
				break;
		}

		return color;
	}

	public void UpdateMap( CharacterData src, DisplayMode mode = DisplayMode.ElementColor )
	{
		if( _grids == null )
		{
			return;
		}

		PixelData[,] map = src.bodyMap;

		for( int i = 0; i < map.GetLength( 0 ); i++ )
		{
			for( int j = 0; j < map.GetLength( 1 ); j++ )
			{
				float healthPoint = src.bodyMap[i, j].currentHealthPoint;
				Color color = GetPixelColor( healthPoint, mode );

				_grids[i, j].GetComponent<Renderer>().material.color = color;
			}
		}
	}
}

public enum DisplayMode
{
	Normal = 0,
	BlackAndWhite = 1, //血条展示
	ElementColor = 2 //血条+元素展示

}