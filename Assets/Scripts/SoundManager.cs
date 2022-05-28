using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	public AkInitializer akInitializer;

	public const string soundBankName = "FightSoundBank";

	public const string backGroundMusicBank = "BackGroundMusic";

	public const string backGroundMusicEvent = "PlayBGM";

	private void Awake()
	{
		instance = this;
		object settingObj = Resources.Load( "AkWwiseInitializationSettings" );
		if( settingObj != null )
		{
			AkWwiseInitializationSettings settings = settingObj as AkWwiseInitializationSettings;
			akInitializer.InitializationSettings = settings;
		}
		AkBankManager.UnloadBank( soundBankName );
		AkBankManager.LoadBank( soundBankName, true, true );
		AkBankManager.UnloadBank( backGroundMusicBank );
		AkBankManager.LoadBank( backGroundMusicBank, true, true );
	}

	public void PlaySoundEffect( string eventName )
	{
		Debug.Log( "Play " + eventName );
		AkSoundEngine.PostEvent( eventName, this.gameObject );
	}

	public void PlayBackGroundMusic()
	{
		AkSoundEngine.PostEvent( backGroundMusicEvent, this.gameObject );
	}
}
