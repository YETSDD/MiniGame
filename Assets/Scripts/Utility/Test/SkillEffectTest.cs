using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectTest : MonoBehaviour
{
#if UNITY_EDITOR
	#region EditorParams

	public int cornerX, cornerY;

	public int damageWidth, damageHeight;

	public CharacterControllerBase targetCharacter;

	public float basicDamageAmount;
	#endregion
#endif

	public void DealRectDamageToCharacter( CharacterControllerBase target, float damageAmount )
	{
		DamageBase damage = new DamageBase( target.character.width, target.character.height );
		Vector2Int damagePosition = new Vector2Int( cornerX, cornerY );
		Vector2Int damageSize = new Vector2Int( damageWidth, damageHeight );
		RectInt damageRange = new RectInt( damagePosition, damageSize );

		damage.GenerateRectHealthPointChangeMap( damageRange, damageAmount );
		target.ChangeHealthPoint( damage.healthPointChangeMap );
	}
}
