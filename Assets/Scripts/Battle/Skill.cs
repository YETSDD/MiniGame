using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
	#region EditorParam
	public int cornerX, cornerY;

	public int damageWidth, damageHeight;

	public CharacterBase targetCharacter;
	#endregion

	public void DealRectDamageToCharacter( CharacterBase target, int damageAmount )
	{
		DamageBase damage = new DamageBase( target.characterData.bodyMap.GetLength( 0 ), target.characterData.bodyMap.GetLength( 1 ) );
		float[,] rectHealthPointChangeMap = damage.GenerateRectHealthPointChangeMap( new RectInt( new Vector2Int( cornerX, cornerY ), new Vector2Int( damageWidth, damageHeight ) ), damageAmount );
		target.ChangeHealthPoint( rectHealthPointChangeMap );
	}
}
