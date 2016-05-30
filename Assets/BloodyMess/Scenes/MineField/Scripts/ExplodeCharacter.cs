using UnityEngine;
using System.Collections;


public class ExplodeCharacter : MonoBehaviour, IBloodyMessExplosionEventHandler {
	public MineLevelManager manager;
	// Use this for initialization
	void Start () {
	 manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<MineLevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void OnExplosion(Vector3 position, Vector3 direction) {

		manager.Lose ();

	}
}
