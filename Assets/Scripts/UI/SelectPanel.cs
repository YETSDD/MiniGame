using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class SelectPanel : PanelBase
{//TODO: talent select
	public static SelectPanel instance;

	private Character _player;

	public const int chooseAmount = 3;

	public const int chanceAmountBeforeBattle = 3;

	public Button[] skillSetChoice = new Button[chooseAmount];

	public List<KeyValuePair<Module, SkillSet>> skillSetsToChoose = new List<KeyValuePair<Module, SkillSet>>();

	public Transform layout;

	public KeyValuePair<Module, SkillSet> chosenSkillSet;

	public Button confirm;

	public int chances = 0;

	public Image[] selectBoxs = new Image[chooseAmount];

	protected override void Awake()
	{
		base.Awake();
		instance = this;
		for( int i = 0; i < chooseAmount; i++ )
		{
			//TODO: Encapsulate
			int index = i;
			skillSetChoice[i].onClick.AddListener( () => { SetupSkillSet( index ); } );
		}
		confirm.onClick.AddListener( OnClickConfirm );
		DisableSelectBox();
	}

	public override void Show()
	{
		base.Show();
		_player = CharacterManager.instance.player.character;
		Time.timeScale = 0;
	}

	public override void Hide()
	{
		base.Hide();
		Time.timeScale = 1;
	}

	public void BeforeBattle()
	{
		Show();
		ChooseThreeSkillSets();
		chances = chanceAmountBeforeBattle;
	}

	public void BetweenBattle()
	{
		Show();
		ChooseThreeSkillSets();
		chances = 1;
	}


	private void ChooseThreeSkillSets()
	{
		Dictionary<Module, List<SkillSet>> allSkillSets = new Dictionary<Module, List<SkillSet>>();

		foreach( Module module in _player.modules )
		{
			List<SkillSet> skillSets = new List<SkillSet>();
			foreach( SkillSet set in module.config.skillSetPool )
			{
				skillSets.Add( set );
			}
			allSkillSets.Add( module, skillSets );
		}

		skillSetsToChoose = allSkillSets.GetRandomElements( chooseAmount );
		ShowSkillSetsToChoose();
	}

	private void ShowSkillSetsToChoose()
	{
		for( int i = 0; i < chooseAmount; i++ )
		{
			SelectableSkillSet selectableObject = layout.GetChild( i ).gameObject.GetComponent<SelectableSkillSet>();

			ModuleConfig moduleConfig = skillSetsToChoose[i].Key.config;
			SkillSet skillSet = skillSetsToChoose[i].Value;
			selectableObject.Set( moduleConfig.moduleName, skillSet.shownName, skillSet.ownSkills );
		}
	}

	private void SetupSkillSet( int index )
	{
		chosenSkillSet = skillSetsToChoose[index];
		DisableSelectBox();
		selectBoxs[index].enabled = true;
		Debug.Log( "Choose Button " + index );
	}

	private void DisableSelectBox()
	{
		foreach( Image image in selectBoxs )
		{
			image.enabled = false;
		}
	}

	public void OnClickConfirm()
	{
		Debug.Log( "Confirm" );
		DisableSelectBox();
		chosenSkillSet.Key.SetSkillSet( chosenSkillSet.Value );
		CharacterManager.instance.player.UpdateAvailableSkills();
		chances--;
		if( chances > 0 )
		{
			ChooseThreeSkillSets();
		}
		else
		{
			Hide();
			GameManager.instance.SelectOver();
		}

	}
}
