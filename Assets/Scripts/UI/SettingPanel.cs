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

	public Button killMonster;

	protected override void Awake()
	{
		base.Awake();
		instance = this;
		volume.onValueChanged.AddListener( OnValueChange );
		continueGame.onClick.AddListener( OnClickContinue );
		backToStartPanel.onClick.AddListener( OnClickBack );
		killMonster.onClick.AddListener( OnClickKillMonster );
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
		AkSoundEngine.SetGameObjectOutputBusVolume( SoundManager.instance.gameObject, SoundManager.instance.audioListener.gameObject, value );
		AkSoundEngine.SetGameObjectOutputBusVolume( SoundManager.instance.backGroundMusicObject, SoundManager.instance.audioListener.gameObject, 0.1f * value );
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

	public void OnClickKillMonster()
	{
		if( CharacterManager.instance.monster != null )
		{
			CharacterManager.instance.monster.isAlive = false;
			GameManager.instance.MonsterDie();
			Hide();
		}
	}
}
