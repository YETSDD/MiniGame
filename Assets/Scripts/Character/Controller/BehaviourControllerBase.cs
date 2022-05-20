using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourControllerBase : MonoBehaviour
{
	public CharacterControllerBase self;

	public virtual void OnTurn()
	{
		if( self == null )
		{
			throw new System.Exception( "Self Not Initialized" );
		}

		Prepare();
		self.OnRoundPrepare();
		Act();
		self.OnRoundAct();
		Settle();
		self.OnRoundSettle();
	}

	public virtual void Prepare()
	{
	}

	/// <summary>
	/// �ͷż���
	/// </summary>
	public virtual void Act()
	{
	}

	/// <summary>
	/// ���⶯��
	/// </summary>
	public virtual void Settle()
	{
		Debug.Log( "������һЩ���⶯��" );
	}
}
