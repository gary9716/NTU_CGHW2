using UnityEngine;
using System.Collections;
using RG_GameCamera.CharacterController;
using RG_GameCamera.Extras;

public class PlayerInfo : Human {
	
	vp_FPPlayerDamageHandler damageHandler;
	[HideInInspector]
	public float hpSysFactor = 10f;

	void Awake() {
		EntityManager.Instance.RegisterPlayer (this);
	}

	// Use this for initialization
	void Start () {
		damageHandler = GetComponent<vp_FPPlayerDamageHandler> ();
		this.Health = damageHandler.MaxHealth * hpSysFactor;
	}

	public override void OnHit (HitEntity owner, float damage, Vector3 hitPos)
	{
		base.OnHit (owner, damage, hitPos);
		SendMessage ("Damage", damage / hpSysFactor, SendMessageOptions.DontRequireReceiver);
	}

	protected override void OnDie ()
	{
		base.OnDie ();
		SendMessage ("Die", SendMessageOptions.DontRequireReceiver);
	}

}
