using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
	public DisplayMode displayMode = DisplayMode.ElementColor;

	public GridData gridPrefab;

	public const float gridLength = 1.1f;

	public const float gridWidth = 1.1f;

	private GridData[,] _grids;

	public void InitializeMap( Character src, Transform root )
	{
		int width = src.width;
		int height = src.height;
		_grids = new GridData[width, height];

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				GridData grid = Instantiate( gridPrefab, new Vector3( x * gridWidth, y * gridLength, 0 ), Quaternion.identity, root );

				_grids[x, y] = grid;
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

	public void UpdateMap( Character src, DisplayMode mode = DisplayMode.ElementColor )
	{
		if( _grids == null )
		{
			return;
		}

		int width = src.width;
		int height = src.height;

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				float healthPoint = src.bodyMap[x, y].currentHealthPoint;
				Color color = GetPixelColor( healthPoint, mode );

				_grids[x, y].color = color;
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