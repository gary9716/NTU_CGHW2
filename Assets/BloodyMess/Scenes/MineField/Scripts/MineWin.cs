using UnityEngine;
using System.Collections;

public class MineWin : MonoBehaviour {
	public MineLevelManager manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<MineLevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 13) {
			manager.Win();
		}
	}
}
