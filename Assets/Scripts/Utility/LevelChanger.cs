#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
	public Level level;

	public List<CharacterConfig> configs = new List<CharacterConfig>();

	public List<AIController> controllers = new List<AIController> ();


}

#endif