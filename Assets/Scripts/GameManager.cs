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
	}

	public void SelectOver()
	{
		BattleManager.instance.InitializePlayerController();
		BattlePanel.instance.Show();
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
