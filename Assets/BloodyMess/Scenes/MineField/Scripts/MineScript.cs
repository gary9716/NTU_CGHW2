using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Limb")) {
			if(other.gameObject.GetComponent<Limb>()) {
				GameObject limb = other.gameObject.GetComponent<Limb>().parent;
				CharacterSetup character = limb.GetComponent<CharacterSetup>();

				Vector3 position = limb.transform.position;
				Vector3 direction = other.gameObject.transform.position - transform.position;

				character.ExplodeBody(position, direction);
			}
		}

	}
}
