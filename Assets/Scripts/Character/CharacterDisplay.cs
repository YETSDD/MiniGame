using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
	public DisplayMode displayMode = DisplayMode.ElementColor;

	public GridData gridPrefab;

	public const float gridLength = 1.1f;

	public const float gridWidth = 1.1f;

	public GridData[,] grids;

	public void InitializeMap( Character source, Transform root )
	{
		int width = source.width;
		int height = source.height;
		grids = new GridData[width, height];

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				GridData grid = Instantiate( gridPrefab, root );
				grid.transform.localPosition = new Vector3( x * gridWidth, y * gridLength, 0 );

				grids[x, y] = grid;
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

	public void UpdateMap( Character source, DisplayMode mode = DisplayMode.ElementColor )
	{
		if( grids == null )
		{
			throw new System.Exception( "_grids Not Initialized" );
		}

		int width = source.width;
		int height = source.height;

		for( int x = 0; x < width; x++ )
		{
			for( int y = 0; y < height; y++ )
			{
				float healthPoint = source.bodyMap[x, y].currentHealthPoint;
				Color color = GetPixelColor( healthPoint, mode );

				grids[x, y].color = color;
			}
		}
	}
}

public enum DisplayMode
{
	Normal,
	BlackAndWhite, //血条展示
	ElementColor //血条+元素展示

}