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

	public void StartGame()
	{
		Debug.Log( "Game Start" );
		CharacterManager.instance.GeneratePlayer();
		StartPanel.instance.Hide();
		SelectPanel.instance.Show();
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
