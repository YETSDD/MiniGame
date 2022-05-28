using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : PanelBase
{
	public static SettingPanel instance;

	public Slider volume;

	public Button continueGame;

	public Button backToStartPanel;


	protected override void Awake()
	{
		base.Awake();
		instance = this;
		volume.onValueChanged.AddListener( OnValueChange );
		continueGame.onClick.AddListener( OnClickContinue );
		backToStartPanel.onClick.AddListener( OnClickBack );
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

	public void OnValueChange( float value )
	{
		Debug.Log( "value: " + value );
		//AkSoundEngine.SetVolumeThreshold( value );
		AkSoundEngine.SetGameObjectOutputBusVolume( SoundManager.instance.gameObject, SoundManager.instance.audioListener.gameObject, value );
		AkSoundEngine.SetRTPCValue( "bus_volume", value );
	}

	public void OnClickContinue()
	{
		Hide();
	}

	public void OnClickBack()
	{
		GameManager.instance.BackToStart();
		Hide();
	}
}
