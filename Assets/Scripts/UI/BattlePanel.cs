using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;
public class BattlePanel : PanelBase
{
	public static BattlePanel instance;

	public TextMeshProUGUI enemyName;

	public Transform skillLayout;

	public SkillPresentation skillPrefab;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
	}

	public override void Show()
	{
		base.Show();
		UpdateSkillList();
	}

	public override void Hide()
	{
		base.Hide();
	}

	public void UpdateSkillList()
	{
		Character player = CharacterManager.instance.player.character;

		skillLayout.DestroyAllChilds();

		foreach( SkillBase skill in player.allAvailableSkills )
		{
			SkillPresentation skillPresentation = Instantiate( skillPrefab, skillLayout );
			skillPresentation.Set( skill.shownName, skill.image );
			skillPresentation.SetButton( true );
		}
	}
}
