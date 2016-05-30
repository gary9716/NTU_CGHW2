
 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//This is the main script for Bloody Mess. Editing this is not recommended by those that are not programmers.
////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//Here we set up the events for OnLimbDeath and OnDeath
public interface IBloodyMessEventHandler : IEventSystemHandler {
	void OnLimbDeath(int limbID, GameObject spawnedLimb, GameObject removedLimb, Vector3 attackerPosition, Vector3 attackerDirection); //called when a limbs health = 0
	void OnDeath(Transform ragdoll); //called when the total health = 0 and a ragdoll is spawned (notice if you never call RagdollDeath() this will not function)

}
//Custom input module that can send the events

public interface IBloodyMessHitEventHandler : IEventSystemHandler {
	void OnLimbHit(int limbID); //called whenever a limb is hit (the hit comes from an outside script like a raycast or collision)

}

public interface IBloodyMessExplosionEventHandler : IEventSystemHandler {
	void OnExplosion(Vector3 position, Vector3 direction); //called whenever useExplosion is true and an outside script starts an explosion returns the position and direction of the explosion.
}

[System.Serializable]
public class CharacterSetup : MonoBehaviour {

	public string characterName = "Character Name";
	public bool loadPrevious = false; //this is true when you want to use a saving system to load saved health information (example between level loads)
	public GameObject target;   //initializes what can use the Bloody Mess Event System, leave blank if your event scripts are on this gameObject
	public GameObject renderers; //a collection of all your characters renderers
	public GameObject skeleton; //top level of your characters skeletal heirarchy 
	public bool usePooling = false; //if you are using pooling turn this to true, sets if you want to destroy the prefab
	public float destroyTimer = 10.0f; //how long after death this prefab will be destroyed (only works if useDestroy = true)


	//ragdoll setup

	[HideInInspector]
	public bool canSpawn; //used to keep multiple ragdolls from spawning when using a fast firing gun
	public bool useAutomaticRagdoll = true; //set to true if you want to automatically ragdoll on death (setting to false allows you to do different things when health = 0 but you will have to call ragdoll death manually)
	public Transform ragdoll;   //the set up ragdoll you want to replace your dead character with
	public float ragdollWaitTime = 0.1f; //how long after heath = 0 you replace the dead character(use to sync with death anims or effects)
	public bool destroyRagdolls = true; //true if you want to remove ragdolls after a certain amount of time (keep true for best performance)
	public float bodyStayTime = 15.0f; //how long ragdolls reamain in the scene


	//health setup
	public float health = 100.0f; //actual health of the character
	public float maxHealth = 100.0f; //maximum health the character can have
	[HideInInspector]
	public float headHealth = 25f; 

	public float maxHeadHealth = 25f;
	[HideInInspector]
	public float rightHandHealth = 25f;
	public float maxRightHandHealth = 25f;
	[HideInInspector]
	public float leftHandHealth = 25f;
	public float maxLeftHandHealth = 25f;
	[HideInInspector]
	public float rightLegHealth = 100f;
	public float maxRightLegHealth = 100f;
	[HideInInspector]
	public float leftLegHealth = 100f;
	public float maxLeftLegHealth = 100f;
	[HideInInspector]
	public float rightUpperArmHealth = 50f;
	public float maxRightUpperArmHealth = 50f;
	[HideInInspector]
	public float leftUpperArmHealth = 50f;
	public float maxLeftUpperArmHealth = 50f;
	[HideInInspector]
	public float rightForArmHealth = 50f;
	public float maxRightForArmHealth = 50f;
	[HideInInspector]
	public float leftForArmHealth = 50f;
	public float maxLeftForArmHealth = 50f;
	[HideInInspector]
	public float extra1Health = 100f;
	public float maxExtra1Health = 100f;
	[HideInInspector]
	public float extra2Health = 100f;
	public float maxExtra2Health = 100f;
	[HideInInspector]
	public float extra3Health = 100f;
	public float maxExtra3Health = 100f;
	[HideInInspector]
	public float extra4Health = 100f;
	public float maxExtra4Health = 100f;

	//Multiplier setup
	//Each of these multiplies the incoming damage (set below 1 for subtraction/division)
	public float criticalMultiplier = 10.0f;
	public float headMultiplier = 5.0f;
	public float handMultiplier = 0.3f;
	public float armMultiplier = 0.5f;
	public float legMultiplier = 0.5f;
	public float bodyMultiplier = 1.0f;
	public float extra1Multiplier = 1.0f;
	public float extra2Multiplier = 1.0f;
	public float extra3Multiplier = 1.0f;
	public float extra4Multiplier = 1.0f;



	public bool advancedRagdoll;

	public bool useHeadDismember; //set true if you want to allow head dismemberment
	public bool useBodyDismember; // set true if you want to allow body part dismemberment
	public bool useExplosion; //set true if you want to allow full body explosions

	public int weaponTypeForHead; //weaponType int that can dismember the head 
	public int weaponTypeForLimbs; //weaponType int that can dismember limbs
	public int weaponTypeForBody; //weaponType int that can cut the torso in half

	//Skinned Mesh Renderer Setup
	//you can leave these blank if you do not have the body part
	public GameObject[] head;
	public GameObject[] rightHands;
	public GameObject[] leftHands;
	public GameObject[] rightLegs;
	public GameObject[] leftLegs;
	public GameObject[] rightUpperArm;
	public GameObject[] leftUpperArm;
	public GameObject[] rightForArm;
	public GameObject[] leftForArm;
	public GameObject[] upperBody;
	public GameObject[] lowerBody;
	public GameObject[] extra1;
	public GameObject[] extra2;
	public GameObject[] extra3;
	public GameObject[] extra4;

	// Eyes can sometimes not be skinned to the bones of a character, place them here if that is the case
	public GameObject rEye;
	public GameObject lEye;

	//triggers for damage colleciton
	public Collider[] headColliders;
	public Collider[] rightHandColliders;
	public Collider[] leftHandColliders;
	public Collider[] rightLegColliders;
	public Collider[] leftLegColliders;
	public Collider[] rightUpperArmColliders;
	public Collider[] leftUpperArmColliders;
	public Collider[] rightForArmColliders;
	public Collider[] leftForArmColliders;
	public Collider[] upperBodyColliders;
	public Collider[] lowerBodyColliders;
	public Collider[] extra1Colliders;
	public Collider[] extra2Colliders;
	public Collider[] extra3Colliders;
	public Collider[] extra4Colliders;

	//bools to send to the ragdoll so it can know what parts are missing on death
	[HideInInspector]
	public bool headOff = false;
	[HideInInspector]
	public bool rightUpperOff = false;
	[HideInInspector]
	public bool leftUpperOff = false;
	[HideInInspector]
	public bool leftLegOff = false;
	[HideInInspector]
	public bool rightLegOff = false;
	[HideInInspector]
	public bool rightForArmOff = false;
	[HideInInspector]
	public bool leftForArmOff = false;
	[HideInInspector]
	public bool rightHandOff = false;
	[HideInInspector]
	public bool leftHandOff = false;
	[HideInInspector]
	public bool upperBodyOff = false;
	[HideInInspector]
	public bool lowerBodyOff = false;
	[HideInInspector]
	public bool extra1Off = false;
	[HideInInspector]
	public bool extra2Off = false;
	[HideInInspector]
	public bool extra3Off = false;
	[HideInInspector]
	public bool extra4Off = false;


	//Body parts to spawn when shot off
	public Transform headModel;
	public Transform rightHandModel;
	public Transform leftHandModel;
	public Transform rightLegModel;
	public Transform leftLegModel;
	public Transform rightUpperArmModel;
	public Transform leftUpperArmModel;
	public Transform rightForArmModel;
	public Transform leftForArmModel;
	public Transform upperBodyModel;
	public Transform extra1Model;
	public Transform extra2Model;
	public Transform extra3Model;
	public Transform extra4Model;

	//All the Transforms(gameObjects) you want to spawn when a character explodes (can be anything and not necissarily body parts)
	public Transform[] explosionParts;



	//private variables DO NOT TOUCH
	private float damageAMT;  //this is used to pass multiplied damage
	private int limbID; //this is used to pass the hitLimb type through the event system

	//Here we are going to intialize health on a brand new character 
	void Awake () {
		if (!loadPrevious && !usePooling) {
			health = maxHealth;
			headHealth = maxHeadHealth;
			rightHandHealth = maxRightHandHealth;
			leftHandHealth = maxLeftHandHealth;
			rightLegHealth = maxRightLegHealth;
			leftLegHealth = maxLeftLegHealth;
			rightUpperArmHealth = maxRightUpperArmHealth;
			leftUpperArmHealth = maxLeftUpperArmHealth;
			leftForArmHealth = maxLeftForArmHealth;
			rightForArmHealth = maxRightForArmHealth;
			extra1Health = maxExtra1Health;
			extra2Health = maxExtra2Health;
			extra3Health = maxExtra3Health;
			extra4Health = maxExtra4Health;
		}

		if(loadPrevious && !usePooling) {
			//initiate your loading of health information from a saved state here
		}
	}



	//this is used for initiailization for pooling
	void OnEnable() {
		if (usePooling && !loadPrevious) {
			health = maxHealth;
			headHealth = maxHeadHealth;
			rightHandHealth = maxRightHandHealth;
			leftHandHealth = maxLeftHandHealth;
			rightLegHealth = maxRightLegHealth;
			leftLegHealth = maxLeftLegHealth;
			rightUpperArmHealth = maxRightUpperArmHealth;
			leftUpperArmHealth = maxLeftUpperArmHealth;
			leftForArmHealth = maxLeftForArmHealth;
			rightForArmHealth = maxRightForArmHealth;
			extra1Health = maxExtra1Health;
			extra2Health = maxExtra2Health;
			extra3Health = maxExtra3Health;
			extra4Health = maxExtra4Health;

			//reset to default
			headOff = false;
			rightUpperOff = false;
			leftUpperOff = false;
			leftLegOff = false;
			rightLegOff = false;
			rightForArmOff = false;
			leftForArmOff = false;
			rightHandOff = false;
			leftHandOff = false;
			upperBodyOff = false;
			lowerBodyOff = false;
			extra1Off = false;
			extra2Off = false;
			extra3Off = false;
			extra4Off = false;

		}
	}


	// Use this for initialization
	void Start () {
		canSpawn = true;
	}



	// Apply damage amount to total health and the body part hit with the following limbIDs
	//0 = head, 1 = rightHand, 2 = leftHand, 3 = rightLeg, 4 = leftLeg, 5 = rightUpperArm,
	//6 = leftUpperArm, 7 = rightForArm, 8 = leftForArm, 9 = upperBody, 10 = lowerBody, 11 = extra1, 12 = extra2, 13 = extra3,
	// 14 = extra4, 15 = critical
	public void ApplyDamage (float damage, GameObject hitobj, int weaponType, Vector3 attackDirection, Vector3 attackerPosition) {
		//if there is no target specified for the event system then this gameObject is the target
		if (target == null) {
			target = this.gameObject;
		}

		//This switch is the heart of Bloody mess and does all the damage and limb death handling
		//For each tag it adds the multiplier to incoming damage, decides if the limb is dead, hides the appropriate body part, and then sends information on to the 
		//limb spawning system. If you want to add your own limbs you need to add them at the end of this with new cases and new limbIDs associated with them
		switch(hitobj.tag) {

			case "Head":
				damageAMT = damage * headMultiplier;
				
				headHealth -= damageAMT;
				if (headHealth<= 0.0f) headHealth = 0.0f;
				if (headHealth <= 0 && head != null && useHeadDismember && weaponType >= weaponTypeForHead) {
					headOff = true;
					foreach (GameObject headPart in head) {
						headPart.SetActive(false);
						
						foreach(Collider headCollider in headColliders) {
							headCollider.enabled = false;
					
						}
				}
					

					

					SpawnBodyPart(0,headModel,attackerPosition, attackDirection, hitobj);
				}
				limbID = 0;
				break;

			case "RightHand":
				damageAMT = damage * handMultiplier;
		
				rightHandHealth -= damageAMT;
				if (rightHandHealth<= 0.0f) rightHandHealth = 0.0f;
				if (rightHandHealth <= 0 && rightHands != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					rightHandOff = true;
					foreach (GameObject rightHand in rightHands) {
					rightHand.SetActive(false);
					
					
					foreach(Collider rightHandCollider in rightHandColliders) {
						rightHandCollider.enabled = false;
					}
				}
					
					

					SpawnBodyPart(1,rightHandModel, attackerPosition, attackDirection, hitobj);
				}
				limbID = 1;
				break;

			case "LeftHand":
				damageAMT = damage * handMultiplier;
				leftHandHealth -= damageAMT;
				if (leftHandHealth <= 0.0f) leftHandHealth = 0.0f;
				if (leftHandHealth <= 0 && leftHands != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					leftHandOff = true;

					foreach (GameObject leftHand in leftHands) {
						leftHand.SetActive(false);
					
					
						foreach(Collider leftHandCollider in leftHandColliders) {
							leftHandCollider.enabled = false;
						}
					}
					
					

					SpawnBodyPart(2,leftHandModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 2;
				break;

			case "RightLeg":
				damageAMT = damage * legMultiplier;
				rightLegHealth -= damageAMT;
				if (rightLegHealth <= 0.0f) rightLegHealth = 0.0f;
				if(rightLegHealth <= 0 && rightLegs != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					rightLegOff = true;
					
					
					foreach (GameObject rightLeg in rightLegs) {
						rightLeg.SetActive(false);

					
						foreach(Collider rightLegCollider in rightLegColliders) {
							rightLegCollider.enabled = false;
						}
					}
					SpawnBodyPart(3,rightLegModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 3;
				
				break;

			case "LeftLeg":
				damageAMT = damage * legMultiplier;
				leftLegHealth -= damageAMT;
				if (leftLegHealth <= 0.0f) leftLegHealth = 0.0f;
				if(leftLegHealth<= 0 && leftLegs != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					leftLegOff = true;
					
					
					foreach (GameObject leftLeg in leftLegs) {
						leftLeg.SetActive(false);


						foreach (Collider leftLegCollider in leftLegColliders) {
						leftLegCollider.enabled = false;
						}
					}
					SpawnBodyPart(4,leftLegModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 4;
				
				break;

			case "RightUpper":
				damageAMT = damage * armMultiplier;
				rightUpperArmHealth -= damageAMT;
				if (rightUpperArmHealth <= 0.0f) rightUpperArmHealth = 0.0f;
				if (rightUpperArmHealth <= 0 && rightUpperArm != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					rightUpperOff = true;


					foreach (GameObject rightUpper in rightUpperArm) {
						rightUpper.SetActive(false);
						foreach (Collider rightUpperArmCollider in rightUpperArmColliders) {
							rightUpperArmCollider.enabled = false;
						}
					}
					SpawnBodyPart(5, rightUpperArmModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 5;
				break;

			case "LeftUpper":
				damageAMT = damage * armMultiplier;
				leftUpperArmHealth -= damageAMT;
				if (leftUpperArmHealth <= 0.0f) leftUpperArmHealth = 0.0f;
				if (leftUpperArmHealth <= 0 && leftUpperArm != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					leftUpperOff = true;


					foreach(GameObject leftUpper in leftUpperArm) {
						leftUpper.SetActive(false);
						foreach (Collider leftUpperArmCollider in leftUpperArmColliders) {
							leftUpperArmCollider.enabled = false;
						}
					}
					SpawnBodyPart(6,leftUpperArmModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 6;
				break;

			case "RightForeArm":
				damageAMT = damage * armMultiplier;
				rightForArmHealth -=damageAMT;
				if (rightForArmHealth <= 0.0f) rightForArmHealth = 0.0f;
				if (rightForArmHealth <= 0 && rightForArm != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					rightForArmOff = true;


					foreach (GameObject rightLowerArm in rightForArm) {
						rightLowerArm.SetActive(false);
						foreach (Collider rightForArmCollider in rightForArmColliders) {
							rightForArmCollider.enabled = false;
						}
					}
					SpawnBodyPart(7,rightForArmModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 7;
				break;


		
			case "LeftForeArm":
				damageAMT = damage * armMultiplier;
				leftForArmHealth -= damageAMT;
				if (leftForArmHealth <= 0.0f) leftForArmHealth = 0.0f;
				if (leftForArmHealth <= 0 && leftForArm != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					leftForArmOff = true;


					foreach (GameObject leftLowerArm in leftForArm) {
						leftLowerArm.SetActive(false);
						foreach (Collider leftForArmCollider in leftForArmColliders) {
							leftForArmCollider.enabled = false;
						}
					}
					SpawnBodyPart(8,leftForArmModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 8;
				break;

			case "UpperBody":
				damageAMT = damage * bodyMultiplier;
				float healthAMT = health;
				healthAMT -= damageAMT;
				if (healthAMT <= 0 && upperBody != null && useBodyDismember && weaponType >= weaponTypeForBody) {
					upperBodyOff = true;
					foreach (GameObject upper in upperBody) {
						upper.SetActive(false);
						foreach(Collider upperBodyCollider in upperBodyColliders) {
							upperBodyCollider.enabled = false;
						}
					}
				SpawnBodyPart(9,upperBodyModel,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 9;
				break;

			case "LowerBody":
				damageAMT = damage * bodyMultiplier;
				limbID = 10;
				break;

			case "Extra1":
				damageAMT = damage * extra1Multiplier;
				
				extra1Health -= damageAMT;
				if (extra1Health <= 0.0f) extra1Health = 0.0f;
				if (extra1Health <= 0 && extra1 != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					extra1Off = true;
				
					
					foreach (GameObject rend in extra1) {
						rend.SetActive(false);
						foreach (Collider extra1Collider in extra1Colliders) {
							extra1Collider.enabled = false;
						}
					}
					SpawnBodyPart(11, extra1Model,attackerPosition, attackDirection, hitobj);
				}
				limbID = 11;
				break;

			case "Extra2":
				damageAMT = damage * extra2Multiplier;
				extra2Health -= damageAMT;
				if (extra2Health <= 0.0f) extra2Health = 0.0f;
				if (extra2Health <= 0 && extra2 != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					extra2Off = true;
				
					
					foreach (GameObject rend in extra2) {
						rend.SetActive(false);
						foreach (Collider extra2Collider in extra2Colliders) {
							extra2Collider.enabled = false;
						}
					}
					SpawnBodyPart(12, extra2Model,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 12;	
				break;

			case "Extra3":
				damageAMT = damage * extra3Multiplier;
				extra3Health -= damageAMT;
				if (extra3Health <= 0.0f) extra3Health = 0.0f;
				if (extra3Health <= 0 && extra3 != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					extra3Off = true;
				
					
					foreach (GameObject rend in extra3) {
						rend.SetActive(false);
						foreach (Collider extra3Collider in extra3Colliders) {
							extra3Collider.enabled = false;
						}
					}
					SpawnBodyPart(13, extra3Model,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 13;
				break;

			case "Extra4":
				damageAMT = damage * extra4Multiplier;
				extra4Health -= damageAMT;
				if (extra4Health <= 0.0f) extra4Health = 0.0f;
				if (extra4Health <= 0 && extra4 != null && useBodyDismember && weaponType >= weaponTypeForLimbs) {
					extra4Off = true;
				
					
					foreach (GameObject rend in extra4) {
						rend.SetActive(false);
						foreach (Collider extra4Collider in extra4Colliders) {
							extra4Collider.enabled = false;
						}
					}
					SpawnBodyPart(14, extra4Model,attackerPosition, attackDirection, hitobj);
				}
				
				limbID = 14;
				break;

			case "Critical":
				damageAMT = damage * criticalMultiplier;
				limbID = 15;
				break;

			default:
				damageAMT = damage * bodyMultiplier;
				limbID = 20;
				break;
		}

		health -= damageAMT;
		ExecuteEvents.Execute<IBloodyMessHitEventHandler>(target, null, (x,y)=>x.OnLimbHit(limbID)); //send the onLimbHit event to the event system

		if (health <= 0.0f) {
			if (canSpawn && useAutomaticRagdoll) {
				canSpawn = false;
				StartCoroutine(RagdollDeath( attackerPosition, attackDirection));
			}
			
		}
	}

	//handles ragdoll spawning upon character death and sends the OnDeath event
	public IEnumerator RagdollDeath (Vector3 position, Vector3 direction){
		if (target == null) {
			target = this.gameObject;
		}
		yield return new WaitForSeconds(ragdollWaitTime);
		//here we replace the character with a ragdoll copy

		if (!advancedRagdoll) 
		{
			if(!usePooling) {
				if (ragdoll) {
					Rigidbody rigid = gameObject.GetComponent<Rigidbody>();
					Destroy (rigid);
					Collider col = gameObject.GetComponent<Collider>();
					col.enabled = false;
					Transform ragdollClone = Instantiate(ragdoll, transform.position, transform.rotation) as Transform;
					RagdollLogic ragLogic = ragdollClone.GetComponent<RagdollLogic>();
					ragLogic.parent = this.gameObject.GetComponent<CharacterSetup>();
					ExecuteEvents.Execute<IBloodyMessEventHandler>(target, null, (x,y)=>x.OnDeath(ragdollClone));

					CopyOriginalTransforms(transform, ragdoll); //this will make sure the ragodoll comes in at the same "pose" as the previous model
					StartCoroutine(DestroyMainObject());


				}
			} else {
				//enter spawn scripting from your pooling asset

				CopyOriginalTransforms(transform, ragdoll);
			}
			//effictively hide the character for now
			renderers.SetActive(false);
			skeleton.SetActive(false);
			//if we are not using pooling then we need to destroy the main object after a few seconds
		}
		else
		{
			Collider[] cols = gameObject.GetComponentsInChildren<Collider>();
			foreach (Collider col in cols)
			{
				Rigidbody rigid = col.GetComponent<Rigidbody>();
				if(col.enabled == true)
				{
					col.isTrigger = false;
					rigid.isKinematic = false;
				}
				else
				{
					rigid.isKinematic = false;
					rigid.useGravity = false;
				}


			}
			Rigidbody _rigid = gameObject.GetComponent<Rigidbody>();
			_rigid.isKinematic = true;
			Collider _col = gameObject.GetComponent<Collider>();
			_col.enabled = false;

			if(!usePooling)
				StartCoroutine(DestroyMainObject());

		}





	}

	//similar to RagdollDeath, this function spawns body parts and sends the OnLimbDeath() Event
	void SpawnBodyPart (int limbID, Transform bodyPart, Vector3 attackPosition, Vector3 attackDirection, GameObject hitObj) {
		if (!usePooling) {

			Transform bodyPartClone = Instantiate(bodyPart, transform.position, transform.rotation) as Transform;
			GameObject limbClone = bodyPartClone.gameObject;
			RagdollLogic ragLogic = limbClone.GetComponent<RagdollLogic>();
			ragLogic.parent = this.gameObject.GetComponent<CharacterSetup>();


			ExecuteEvents.Execute<IBloodyMessEventHandler>(target, null, (x,y)=>x.OnLimbDeath(limbID, limbClone, hitObj, attackPosition, attackDirection));
			//same as above
			CopyOriginalTransforms(transform, bodyPart);
		} else {
			//spawn limbs with pooling
			//ExecuteEvents.Execute<IBloodyMessEventHandler>(target, null, (x,y)=>x.OnLimbDeath(limbID, limbClone, hitObj, attackPosition, attackDirection));
			//same as above
			CopyOriginalTransforms(transform, bodyPart);
		}

	}

	//this replicates all the body transforms between the original character and spawned ragdolls so the process of replacing them appears seamless
	static void CopyOriginalTransforms ( Transform original , Transform spawned ){
		spawned.position = original.position;
		spawned.rotation = original.rotation;
		
		foreach(Transform child in spawned) {
			// Match the transform with the same name
			Transform curOrig = original.Find(child.name);
			if (curOrig)
				CopyOriginalTransforms(curOrig, child);
		}
	}

	//used to explode the entire body,  you must call from an outside script to activate
	public void ExplodeBody(Vector3 position, Vector3 direction) {
		if (target == null) {
			target = this.gameObject;
		}
		Rigidbody charRigid = gameObject.GetComponent<Rigidbody>();
		charRigid.constraints = RigidbodyConstraints.FreezeAll;
		ExecuteEvents.Execute<IBloodyMessExplosionEventHandler>(target, null, (x,y)=>x.OnExplosion(position, direction));
		headOff = true;
		upperBodyOff = true;
		rightUpperOff = true;
		leftUpperOff = true;
		rightForArmOff = true;
		leftForArmOff = true;
		rightHandOff = true;
		rightLegOff = true;
		leftHandOff = true;
		leftLegOff = true;
		renderers.SetActive(false);
		skeleton.SetActive(false);
		StartCoroutine(RagdollDeath(position, direction));
		foreach (Transform explosionPart in explosionParts) {
			Transform bodyPartClone = Instantiate(explosionPart, transform.position, transform.rotation) as Transform;
			GameObject limbClone = bodyPartClone.gameObject;
			RagdollLogic ragLogic = limbClone.GetComponent<RagdollLogic>();
			ragLogic.parent = this.gameObject.GetComponent<CharacterSetup>();
			Rigidbody[] rigids = bodyPartClone.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody rigid in rigids) {
				rigid.AddForce(Vector3.up * 10.0f,ForceMode.Impulse);
				rigid.AddForce(direction * 10.0f,ForceMode.Impulse);
			}

		}

	}

	//destroy this gameobject to remove it from the scene
	IEnumerator DestroyMainObject() {
		yield return new WaitForSeconds(destroyTimer);
		GameObject toDestroy = this.gameObject;
		Destroy(toDestroy,0.1f);
	}



}
