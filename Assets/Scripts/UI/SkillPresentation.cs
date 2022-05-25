using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPresentation : MonoBehaviour
{
	public TextMeshProUGUI skillName;

	public Image skill;

	public Button select;

	public void Set( string skillName, Image skillImage )
	{
		this.skillName.text = skillName;
		this.skill = skillImage;
	}

	public void SetButton( bool active )
	{
		select.enabled = active;
	}
}
	