/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// This script is an example of how you can use your own scripts to link with the healing event system and do character healing
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class MenuHealing : MonoBehaviour {

	private HealingEvents healing; // we need to directly link with the Healing Events script so we can send events from this script

	public GameObject target; //target is what you want to recieve the healing and needs to be passed to the Healing event system

	// Use this for initialization
	void Start () {
		Cursor.visible = true; //used in for the demo
		Cursor.lockState = CursorLockMode.None; //used in for the demo
		healing = gameObject.GetComponent<HealingEvents>(); //get the healing events script from this gameObject
	}
	


	//use the gui to call each of these

	public void AddTotalHealth() {
		healing.HealTotal(300.0f, target); //you need to pass the amount and the target
	}

	public void AddtoLimbHealth(int limbID) {
		healing.HealSpecificLimb(50.0f, limbID, target); //you need to pass the amount and the target
	}

	public void AddtoAllLimbs() {
		healing.HealAllLimbs(100.0f, target); //you need to pass the amount and the target
	}

	//used to return to the main menu in the demo (not needed in your own scripts

	public void MainMenu() {
		Application.LoadLevel("MainMenu");
	}
	
}
