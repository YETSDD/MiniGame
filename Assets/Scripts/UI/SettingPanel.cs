using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : PanelBase
{
	public static SettingPanel instance;

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
}
