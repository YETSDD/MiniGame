using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : PanelBase
{
	public static ResultPanel instance;

	public Image win;

	public Image lose;

	public Button back;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
		win.enabled = false;
		lose.enabled = false;
		back.onClick.AddListener( OnClickBack );
	}

	public override void Show()
	{
		base.Show();
	}

	public override void Hide()
	{
		base.Hide();
	}

	public void Win()
	{
		Show();
		win.enabled = true;
		lose.enabled = false;
	}

	public void Lose()
	{
		Show();
		win.enabled = false;
		lose.enabled = true;
	}

	public void OnClickBack()
	{
		StartPanel.instance.Show();
		Hide();
	}

}
