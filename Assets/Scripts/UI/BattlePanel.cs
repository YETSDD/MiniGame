using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class BattlePanel : PanelBase
{
	public static BattlePanel instance;

	public TextMeshProUGUI enemyName;

	public Transform skillLayout;

	public SkillPresentation skillPrefab;

	public Button moveToNextLevel;

	public int currentLevel = 0;

	public Level level;

	public GameObject mapMask;

	public Interaction interaction;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
	}

	public void Initialize()
	{
		InitializeMap();
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

	private void InitializeMap()
	{
		currentLevel = 0;
		moveToNextLevel.onClick.AddListener( StartLevel );
		mapMask.SetActive( false );
	}

	public void StartLevel()
	{
		mapMask.SetActive( true );
		CharacterManager.instance.GenenrateMonster( level.monsters[currentLevel].Item1 );
		BattleManager.instance.InitializeAIController( level.monsters[currentLevel].Item2 );
		BattleManager.instance.StartBattle();
	}

	public bool FinishLevel()
	{
		if( currentLevel == level.monsters.Count - 1 )
		{
			moveToNextLevel.onClick.RemoveAllListeners();
			GameManager.instance.FianlWin();
			return true;
		}
		currentLevel++;
		mapMask.SetActive( false );
		Hide();
		return false;
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
			SkillBase currentSkill = skill;//WARNING
			skillPresentation.select.onClick.AddListener( () => OnClickSkillButton( currentSkill ) );
		}
	}

	public void OnClickSkillButton( SkillBase skill )
	{
		Debug.Log( "Click Skill: " + skill.shownName );
		BattleManager.instance.SetPlayerSkillToRelease( skill );
		EnableSkillIndicator( skill );
	}

	public GameObject rectIndicator;

	public void EnableSkillIndicator( SkillBase skill )
	{
		interaction.onClick.AddListener( UseSkill );
	}

	private void UseSkill()
	{
		Debug.Log( "UseSkill" );
		SkillBase skill = BattleManager.instance.playerController.skillToRelease;
		switch( skill.indicatorType )
		{
			case SkillIndicatorType.Point:
				break;
			case SkillIndicatorType.Line:
				break;
			case SkillIndicatorType.Rect:
				break;
			case SkillIndicatorType.Circle:
				break;
		}

		Vector2Int start = interaction.startGridPosition;
		Vector2Int end = interaction.endGridPosition;
		CharacterControllerBase player = CharacterManager.instance.player;
		CharacterControllerBase monster = CharacterManager.instance.monster;
		skill.Set( monster, start, end, skill.defaultAmount );
		skill.UseSkill( player, monster );

		DisableSkillIndicator();

		BattleManager.instance.playerController.PrepareOver();
		BattleManager.instance.playerController.ActOver();
		BattleManager.instance.playerController.EndOver();
	}

	public void DisableSkillIndicator()
	{
		interaction.onClick.RemoveListener( UseSkill );
	}
	public void OnMonsterRound()
	{
		//TODO: disable buttons
	}
}
