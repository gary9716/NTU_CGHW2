using UnityEngine;
using System.Collections;
using RG_GameCamera.Extras;

public class EnemyMsgHandler : vp_DamageHandler {

	public Zombie zombieInfo;
	float hpSysFactor = 10f;

	// Use this for initialization
	void Start () {
		if (zombieInfo) {
			zombieInfo.Health = MaxHealth * hpSysFactor;
		}
	}

	public override void Damage (vp_DamageInfo damageInfo)
	{
		if (zombieInfo) {
			zombieInfo.OnHit (damageInfo.OriginalSource.GetComponent<PlayerInfo> (), damageInfo.Damage * hpSysFactor, Vector3.zero);
		}
		base.Damage (damageInfo);
		Debug.Log ("damaged with Info");
	}

	public override void Die ()
	{
		if (zombieInfo) {
			zombieInfo.Die ();
		}
		base.Die ();
		Debug.Log ("died");
	}

}
