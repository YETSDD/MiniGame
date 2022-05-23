using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : PanelBase
{
	public static StartPanel instance;

	public Button StartGame;

	public Button Settings;

	public Button ExitGame;

	private void Awake()
	{
		instance = this;
		InitializeButtons();
	}

	public void InitializeButtons()
	{
		StartGame.onClick.AddListener( OnClickStartGame );
		Settings.onClick.AddListener( OnClickSettings );
		ExitGame.onClick.AddListener( OnClickExitGame );
	}

	public void OnClickStartGame()
	{
		GameManager.instance.StartGame();
	}

	public void OnClickSettings()
	{
		GameManager.instance.Setup();
	}

	public void OnClickExitGame()
	{
		GameManager.instance.ExitGame();
	}
}
