using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StartPanel : PanelBase
{
	public static StartPanel instance;

	public Button startGame;

	public Button settings;

	public Button exitGame;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
		InitializeButtons();
	}

	public void InitializeButtons()
	{
		startGame.onClick.AddListener( OnClickStartGame );
		settings.onClick.AddListener( OnClickSettings );
		exitGame.onClick.AddListener( OnClickExitGame );
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
