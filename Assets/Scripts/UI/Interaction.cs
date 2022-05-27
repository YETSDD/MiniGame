using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent( typeof( RectTransform ) )]
public class Interaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Vector2 start;

	public Vector2 end;

	public UnityEvent onClick;

	public int gridWidthCount = 20;

	public int gridHeightCount = 30;

	public Vector2Int startGridPosition;

	public Vector2Int endGridPosition;

	public void OnPointerDown( PointerEventData eventData )
	{
		GetStartPosistion();
	}

	public void OnPointerUp( PointerEventData eventData )
	{
		GetEndPosistion();
		onClick.Invoke();
	}

	public void GetStartPosistion()
	{
		start = Pointer.current.position.ReadValue();
		Debug.Log( "x: " + start.x + "y: " + start.y );
		startGridPosition = GetGridPosition( start );
	}

	public void GetEndPosistion()
	{
		end = Pointer.current.position.ReadValue();
		Debug.Log( "x: " + end.x + "y: " + end.y );
		endGridPosition = GetGridPosition( end );
	}

	public Vector2Int GetGridPosition( Vector2 screenPostion )
	{
		RectTransform rectTransform = GetComponent<RectTransform>();
		Vector2 localPosition;
		if( RectTransformUtility.ScreenPointToLocalPointInRectangle( rectTransform, screenPostion, Camera.current, out localPosition ) )
		{
			Debug.Log( "local x:" + localPosition.x + "y:" + localPosition.y );
			int gridX = gridWidthCount - 1 + (int)( ( localPosition.x - rectTransform.rect.width / 2 ) / ( rectTransform.rect.width / gridWidthCount ) );
			int gridY = gridHeightCount - 1 + (int)( ( localPosition.y - rectTransform.rect.height / 2 ) / ( rectTransform.rect.height / gridHeightCount ) );

			Debug.Log( "grid: " + gridX + "," + gridY );
			return new Vector2Int( gridX, gridY );
		}
		throw new System.Exception( "Cannot Switch to GridPosition" );
	}
}