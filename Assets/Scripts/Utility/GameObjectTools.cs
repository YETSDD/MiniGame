using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
	public static class GameObjectTools
	{
		public static void DestroyAllChilds( this Transform transform )
		{
			int childCount = transform.childCount;
			if( childCount == 0 )
			{
				return;
			}

			for( int i = childCount - 1; i >= 0; i-- )
			{
				GameObject.Destroy( transform.GetChild( i ).gameObject );
			}
		}
	}
}
