using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		StartPanel.instance.Show();
	}

	public void StartGame()
	{
		Debug.Log( "Game Start" );
		CharacterManager.instance.GeneratePlayer();
		StartPanel.instance.Hide();
		SelectPanel.instance.BeforeBattle();
		BattlePanel.instance.Initialize();
	}

	public void SelectOver()
	{
		BattleManager.instance.InitializePlayerController();
		BattlePanel.instance.Show();
	}

	public void MonsterDie()
	{
		Debug.Log( "Monster Die" );
		BattleManager.instance.Win();
	}

	public void PlayerDie()
	{
		Debug.Log( "Player Die" );
		BattleManager.instance.ResetBattle();
		CharacterManager.instance.BattleFinish();
		BattlePanel.instance.Hide();
		SelectPanel.instance.Hide();
		ResultPanel.instance.Lose();
	}

	public void FianlWin()
	{
		BattleManager.instance.ResetBattle();
		CharacterManager.instance.BattleFinish();
		BattlePanel.instance.Hide();
		SelectPanel.instance.Hide();
		ResultPanel.instance.Win();
	}

	public void Setup()
	{
		SettingPanel.instance.Show();
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
