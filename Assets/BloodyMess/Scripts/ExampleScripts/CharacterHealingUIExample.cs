//This script is an example of how to link the Healing Event System and the character system. 
//It goes on the same gameObject as characterSetup

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterHealingUIExample : MonoBehaviour, IBloodyMessHitEventHandler, IHealingEventHandler {
	private CharacterSetup setup;

	public Text totalHealth;
	public Text headHealth;
	public Text rightArmHealth;
	public Text leftArmHealth;
	public Text rightLegHealth;
	public Text leftLegHealth;
	public Text accuracyAMT;
	public Text speedAMT;
	public Text meleeDamageAMT;
	public Text focusAMT;
	
	private float accuracy;
	private float speed;
	private float meleeDamage;
	private float focus;
	public float maxAccuracy;
	public float maxSpeed;
	public float maxMeleeDamage;
	public float maxFocus;
	
	// Use this for initialization
	void Start () {
		setup = gameObject.GetComponent<CharacterSetup>();
		
		accuracy = (((((setup.leftUpperArmHealth/setup.maxLeftUpperArmHealth) * 0.5f) +
		              ((setup.rightUpperArmHealth/setup.maxRightUpperArmHealth) * 0.5f)) * maxAccuracy) / maxAccuracy) * 100.0f;
		speed = (((((setup.leftLegHealth/setup.maxLeftLegHealth) *  0.5f) +
		           ((setup.rightLegHealth/setup.maxRightLegHealth) * 0.5f)) * maxAccuracy) / maxAccuracy) * 100.0f;
		meleeDamage = accuracy;
		focus = (((setup.headHealth/setup.maxHeadHealth) * maxFocus) / maxFocus) * 100.0f;
		
		
		
		totalHealth.text = ("Total Health:" + ((setup.health/setup.maxHealth) * 100.0f) + "%");
		headHealth.text = ("Head Health:" + ((setup.headHealth/setup.maxHeadHealth) * 100.0f) + "%");
		rightLegHealth.text = ("Right Leg Health:" + ((setup.rightLegHealth/setup.maxRightLegHealth) * 100.0f) + "%");
		leftLegHealth.text = ("Left Leg Health:" + ((setup.leftLegHealth/setup.maxLeftLegHealth) * 100.0f) + "%");
		rightArmHealth.text = ("Right Arm Health:" + ((setup.rightUpperArmHealth/setup.maxRightUpperArmHealth) * 100.0f) + "%");
		leftArmHealth.text = ("Left Arm Health:" + ((setup.leftUpperArmHealth/setup.maxLeftUpperArmHealth) * 100.0f) + "%");
		accuracyAMT.text = ("Accuracy:" + accuracy  + "%");
		speedAMT.text = ("Speed:" + speed + "%");
		meleeDamageAMT.text = ("Melee Damage:" + meleeDamage + "%");
		focusAMT.text = ("Focus:" + focus + "%");
	}




	public void Update() {


	}


	public void OnLimbCollision (int limbID, Collider otherCollider, Collider hitLimb) {

	}
	public void OnLimbHit(int limbID) {



		UpdateUI(limbID);
	}

	public void AddHealth(float amount) {
		setup.health += amount;
		if (setup.health > setup.maxHealth) setup.health = setup.maxHealth;
		UpdateUI(20);
	}
	
	public void AddLimbHealth (float amount) {
		setup.headHealth += amount;
		if(setup.headHealth > setup.maxHeadHealth) setup.headHealth = setup.maxHeadHealth;
		setup.rightHandHealth += amount;
		if (setup.rightHandHealth > setup.maxRightHandHealth) setup.rightHandHealth = setup.maxRightHandHealth;
		setup.leftHandHealth += amount;
		if (setup.leftHandHealth > setup.maxLeftHandHealth) setup.leftHandHealth = setup.maxLeftHandHealth;
		setup.rightForArmHealth += amount;
		if (setup.rightForArmHealth > setup.maxRightForArmHealth) setup.rightForArmHealth = setup.maxRightForArmHealth;
		setup.leftForArmHealth += amount;
		if (setup.leftForArmHealth > setup.maxLeftForArmHealth) setup.leftForArmHealth = setup.maxLeftForArmHealth;
		setup.rightUpperArmHealth += amount;
		if (setup.rightUpperArmHealth > setup.maxRightUpperArmHealth) setup.rightUpperArmHealth = setup.maxRightUpperArmHealth;
		setup.leftUpperArmHealth += amount;
		if (setup.leftUpperArmHealth > setup.maxLeftUpperArmHealth) setup.leftUpperArmHealth = setup.maxLeftUpperArmHealth;
		setup.rightLegHealth += amount;
		if (setup.rightLegHealth > setup.maxRightLegHealth) setup.rightLegHealth = setup.maxRightLegHealth;
		setup.leftLegHealth += amount;
		if (setup.leftLegHealth > setup.maxLeftLegHealth) setup.leftLegHealth = setup.maxLeftLegHealth;
		setup.extra1Health += amount;
		if (setup.extra1Health > setup.maxExtra1Health) setup.extra1Health = setup.maxExtra1Health;
		setup.extra2Health += amount;
		if (setup.extra2Health > setup.maxExtra2Health) setup.extra2Health = setup.maxExtra2Health;
		setup.extra3Health += amount;
		if (setup.extra3Health > setup.maxExtra3Health) setup.extra3Health = setup.maxExtra3Health;
		setup.extra4Health += amount;
		if (setup.extra4Health > setup.maxExtra4Health) setup.extra4Health = setup.maxExtra4Health;
		accuracy = (((((setup.leftUpperArmHealth/setup.maxLeftUpperArmHealth) * 0.5f) +
		              ((setup.rightUpperArmHealth/setup.maxRightUpperArmHealth) * 0.5f)) * maxAccuracy) / maxAccuracy) * 100.0f;
		speed = (((((setup.leftLegHealth/setup.maxLeftLegHealth) *  0.5f) +
		           ((setup.rightLegHealth/setup.maxRightLegHealth) * 0.5f)) * maxAccuracy) / maxAccuracy) * 100.0f;
		meleeDamage = accuracy;
		focus = (((setup.headHealth/setup.maxHeadHealth) * maxFocus) / maxFocus) * 100.0f;
		
		
		
		totalHealth.text = ("Total Health:" + ((setup.health/setup.maxHealth) * 100.0f) + "%");
		headHealth.text = ("Head Health:" + ((setup.headHealth/setup.maxHeadHealth) * 100.0f) + "%");
		rightLegHealth.text = ("Right Leg Health:" + ((setup.rightLegHealth/setup.maxRightLegHealth) * 100.0f) + "%");
		leftLegHealth.text = ("Left Leg Health:" + ((setup.leftLegHealth/setup.maxLeftLegHealth) * 100.0f) + "%");
		rightArmHealth.text = ("Right Arm Health:" + ((setup.rightUpperArmHealth/setup.maxRightUpperArmHealth) * 100.0f) + "%");
		leftArmHealth.text = ("Left Arm Health:" + ((setup.leftUpperArmHealth/setup.maxLeftUpperArmHealth) * 100.0f) + "%");
		accuracyAMT.text = ("Accuracy:" + accuracy  + "%");
		speedAMT.text = ("Speed:" + speed + "%");
		meleeDamageAMT.text = ("Melee Damage:" + meleeDamage + "%");
		focusAMT.text = ("Focus:" + focus + "%");
	}


	///Adds health selectively to limbs based on the GameObject healthTargets Tag

	public void AddLimbHealthSelective (float amount, int limbID) {
		switch(limbID) {
			
		case 0:
			setup.headHealth += amount;
			if(setup.headHealth > setup.maxHeadHealth) setup.headHealth = setup.maxHeadHealth;
			UpdateUI(0);
			break;
			
		case 1:
			setup.rightHandHealth += amount;
			if (setup.rightHandHealth > setup.maxRightHandHealth) setup.rightHandHealth = setup.maxRightHandHealth;
			UpdateUI(1);
			break;
			
		case 2:
			setup.leftHandHealth += amount;
			if (setup.leftHandHealth > setup.maxLeftHandHealth) setup.leftHandHealth = setup.maxLeftHandHealth;
			UpdateUI(2);
			break;
			
		case 3:
			setup.rightLegHealth += amount;
			if (setup.rightLegHealth > setup.maxRightLegHealth) setup.rightLegHealth = setup.maxRightLegHealth;
			UpdateUI(3);
			break;
			
		case 4:
			setup.leftLegHealth += amount;
			if (setup.leftLegHealth > setup.maxLeftLegHealth) setup.leftLegHealth = setup.maxLeftLegHealth;
			UpdateUI(4);
			break;
			
		case 5:
			setup.rightUpperArmHealth += amount;
			if (setup.rightUpperArmHealth > setup.maxRightUpperArmHealth) setup.rightUpperArmHealth = setup.maxRightUpperArmHealth;
			UpdateUI(5);
			break;
			
		case 6:
			setup.leftUpperArmHealth += amount;
			if (setup.leftUpperArmHealth > setup.maxLeftUpperArmHealth) setup.leftUpperArmHealth = setup.maxLeftUpperArmHealth;
			UpdateUI(6);
			break;
			
		case 7:
			setup.rightForArmHealth += amount;
			if (setup.rightForArmHealth > setup.maxRightForArmHealth) setup.rightForArmHealth = setup.maxRightForArmHealth;
			UpdateUI(7);
			break;
			
		case 8:
			setup.leftForArmHealth += amount;
			if (setup.leftForArmHealth > setup.maxLeftForArmHealth) setup.leftForArmHealth = setup.maxLeftForArmHealth;
			UpdateUI(8);
			break;
			
		case 9:
			setup.extra1Health += amount;
			if (setup.extra1Health > setup.maxExtra1Health) setup.extra1Health = setup.maxExtra1Health;
			UpdateUI(9);
			break;
			
		case 10:
			setup.extra2Health += amount;
			if (setup.extra2Health > setup.maxExtra2Health) setup.extra2Health = setup.maxExtra2Health;
			UpdateUI(10);
			break;
			
		case 11:
			setup.extra3Health += amount;
			if (setup.extra3Health > setup.maxExtra3Health) setup.extra3Health = setup.maxExtra3Health;
			UpdateUI(11);
			break;
			
		case 12:
			setup.extra4Health += amount;
			if (setup.extra4Health > setup.maxExtra4Health) setup.extra4Health = setup.maxExtra4Health;
			UpdateUI(12);
			break;
		}
	}

	//update the UI based an integer
	void UpdateUI(int limbID) {
		switch(limbID) {
			
		case 0:
			headHealth.text = ("Head Health:" + ((setup.headHealth/setup.maxHeadHealth) * 100.0f) + "%");
			break;
			
		case 3:
			rightLegHealth.text = ("Right Leg Health:" + ((setup.rightLegHealth/setup.maxRightLegHealth) * 100.0f) + "%");

			break;
			
		case 4:
			leftLegHealth.text = ("Left Leg Health:" + ((setup.leftLegHealth/setup.maxLeftLegHealth) * 100.0f) + "%");

			break;
			
		case 5:
			rightArmHealth.text = ("Right Arm Health:" + ((setup.rightUpperArmHealth/setup.maxRightUpperArmHealth) * 100.0f) + "%");

			break;
			
		case 6:
			leftArmHealth.text = ("Left Arm Health:" + ((setup.leftUpperArmHealth/setup.maxLeftUpperArmHealth) * 100.0f) + "%");

			break;


		case 9:
			totalHealth.text = ("Total Health:" + ((setup.health/setup.maxHealth) * 100.0f) + "%");
			
			break;

		case 10:
			totalHealth.text = ("Total Health:" + ((setup.health/setup.maxHealth) * 100.0f) + "%");
			
			break;
		case 20:
			totalHealth.text = ("Total Health:" + ((setup.health/setup.maxHealth) * 100.0f) + "%");
			break;
		}
		totalHealth.text = ("Total Health:" + ((setup.health/setup.maxHealth) * 100.0f) + "%");
		accuracy = (((((setup.leftUpperArmHealth/setup.maxLeftUpperArmHealth) * 0.5f) +
		              ((setup.rightUpperArmHealth/setup.maxRightUpperArmHealth) * 0.5f)) * maxAccuracy) / maxAccuracy) * 100.0f;
		speed = (((((setup.leftLegHealth/setup.maxLeftLegHealth) *  0.5f) +
		           ((setup.rightLegHealth/setup.maxRightLegHealth) * 0.5f)) * maxAccuracy) / maxAccuracy) * 100.0f;
		meleeDamage = accuracy;
		focus = (((setup.headHealth/setup.maxHeadHealth) * maxFocus) / maxFocus) * 100.0f;

		accuracyAMT.text = ("Accuracy:" + accuracy  + "%");
		speedAMT.text = ("Speed:" + speed + "%");
		meleeDamageAMT.text = ("Melee Damage:" + meleeDamage + "%");
		focusAMT.text = ("Focus:" + focus + "%");
	}
}
