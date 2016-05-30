using UnityEngine;
using System.Collections;

public class humanRespawner : vp_PlayerRespawner {

	public PlayerInfo playerInfo;
	public vp_FPPlayerDamageHandler damageHandler;

	// Use this for initialization
	void Start () {
	
	}

	public override void Reset ()
	{
		base.Reset ();
		playerInfo.Health = damageHandler.CurrentHealth * playerInfo.hpSysFactor;
		playerInfo.Dead = false;
	}
}
