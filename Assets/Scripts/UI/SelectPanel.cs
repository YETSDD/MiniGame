using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : PanelBase
{
	public static SelectPanel instance;

	public Character player;

	public Button[] skillSetsToChoose = new Button[3];

	private void Awake()
	{
		instance = this;
	}

	public override void Show()
	{
		base.Show();
		Time.timeScale = 0;
	}

	public override void Hide()
	{
		base.Hide();
		Time.timeScale = 1;
	}

	private void OnEnable()
	{

	}

	private void OnDisable()
	{
		
	}


}
