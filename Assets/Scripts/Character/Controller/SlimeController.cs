using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class SlimeController : BasicAIController
{
	public const string slimeCore = "ʷ��ķ����";

	public const string slimeBody = "ʷ��ķ����Χ����";

	public PixelData core;
	protected override void Awake()
	{
		base.Awake();
	}
	public override void End()
	{
		base.End();
		//TODO: Change core 
		var map = self.character.bodyMap;
		List<PixelData> toChoose = new List<PixelData>();
		List<PixelData> backGround = new List<PixelData>();
		foreach( PixelData pixel in map )
		{
			if( pixel.moduleRef == null )
			{
				backGround.Add( pixel );
				continue;
			}
			if( pixel.moduleRef.moduleName == slimeCore )
			{
				core = pixel;
			}
			if( pixel.moduleRef.moduleName == slimeBody && pixel.currentHealthPoint > 0 )
			{
				toChoose.Add( pixel );
			}

		}
		if( core != null && core.currentHealthPoint > 0 && self.isAlive )
		{
			SwitchData( core, toChoose.GetRandomElement() );
		}
	}

	private void SwitchData( PixelData core, PixelData body )
	{
		PixelData media = new PixelData();
		media.LoadPixelData( core );
		core.LoadPixelData( body );
		body.LoadPixelData( media );
	}
}
