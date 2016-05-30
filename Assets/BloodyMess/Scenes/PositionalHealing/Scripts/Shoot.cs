using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public float damage = 50;
	public LayerMask hitMask;
	private Transform mainCamTransform;
	public int weaponType;
	// Use this for initialization
	void Start () {
		mainCamTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			weaponType = 0;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast (ray, out hit, 1000f, hitMask)) {
				
				
				
				
				
				
				//call the ApplyDamage() function on the enenmy CharacterSetup script
				if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Limb")){
					Vector3 direction = hit.collider.transform.position - transform.position;

					if(hit.collider.gameObject.GetComponent<Limb>()){
						GameObject parent = hit.collider.gameObject.GetComponent<Limb>().parent;
						CharacterSetup character = parent.GetComponent<CharacterSetup>();
						character.ApplyDamage(damage, hit.collider.gameObject, weaponType, direction, mainCamTransform.position);
					}
					
					
				}
				
			}
			
		}
	}

	void FixedUpdate () {


	}

	public void ResetLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
