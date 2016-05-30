using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public Transform zombie;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J))
			SpawnRightZombie();

	}


	public void SpawnRightZombie(){
		Transform zombieClone = Instantiate (zombie, spawnPoint.position, spawnPoint.rotation) as Transform; 
	}


}
