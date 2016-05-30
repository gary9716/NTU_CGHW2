using UnityEngine;
using System.Collections;

public class HealingStarterScript : MonoBehaviour, IHealingEventHandler {
	private CharacterSetup setup;
	

	
	// Use this for initialization
	void Start () {
		setup = gameObject.GetComponent<CharacterSetup>();
		

	}
	
	
	
	
	public void Update() {
		
		
	}
	
	public void AddHealth(float amount) {
		setup.health += amount;
		if (setup.health > setup.maxHealth) setup.health = setup.maxHealth;

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

	}
	
	
	///Adds health selectively to limbs based on the GameObject healthTargets Tag
	
	public void AddLimbHealthSelective (float amount, int limbID) {
		switch(limbID) {
			
		case 0:
			setup.headHealth += amount;
			if(setup.headHealth > setup.maxHeadHealth) setup.headHealth = setup.maxHeadHealth;

			break;
			
		case 1:
			setup.rightHandHealth += amount;
			if (setup.rightHandHealth > setup.maxRightHandHealth) setup.rightHandHealth = setup.maxRightHandHealth;

			break;
			
		case 2:
			setup.leftHandHealth += amount;
			if (setup.leftHandHealth > setup.maxLeftHandHealth) setup.leftHandHealth = setup.maxLeftHandHealth;

			break;
			
		case 3:
			setup.rightLegHealth += amount;
			if (setup.rightLegHealth > setup.maxRightLegHealth) setup.rightLegHealth = setup.maxRightLegHealth;

			break;
			
		case 4:
			setup.leftLegHealth += amount;
			if (setup.leftLegHealth > setup.maxLeftLegHealth) setup.leftLegHealth = setup.maxLeftLegHealth;

			break;
			
		case 5:
			setup.rightUpperArmHealth += amount;
			if (setup.rightUpperArmHealth > setup.maxRightUpperArmHealth) setup.rightUpperArmHealth = setup.maxRightUpperArmHealth;

			break;
			
		case 6:
			setup.leftUpperArmHealth += amount;
			if (setup.leftUpperArmHealth > setup.maxLeftUpperArmHealth) setup.leftUpperArmHealth = setup.maxLeftUpperArmHealth;

			break;
			
		case 7:
			setup.rightForArmHealth += amount;
			if (setup.rightForArmHealth > setup.maxRightForArmHealth) setup.rightForArmHealth = setup.maxRightForArmHealth;

			break;
			
		case 8:
			setup.leftForArmHealth += amount;
			if (setup.leftForArmHealth > setup.maxLeftForArmHealth) setup.leftForArmHealth = setup.maxLeftForArmHealth;

			break;
			
		case 9:
			setup.extra1Health += amount;
			if (setup.extra1Health > setup.maxExtra1Health) setup.extra1Health = setup.maxExtra1Health;

			break;
			
		case 10:
			setup.extra2Health += amount;
			if (setup.extra2Health > setup.maxExtra2Health) setup.extra2Health = setup.maxExtra2Health;

			break;
			
		case 11:
			setup.extra3Health += amount;
			if (setup.extra3Health > setup.maxExtra3Health) setup.extra3Health = setup.maxExtra3Health;

			break;
			
		case 12:
			setup.extra4Health += amount;
			if (setup.extra4Health > setup.maxExtra4Health) setup.extra4Health = setup.maxExtra4Health;

			break;
		}
	}
	


}
