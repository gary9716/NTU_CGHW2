
//////////////////////////////////////////////////////////////////////////////////////
/// This script handles all Ragdoll Logic. It is designed to recieve information
/// from the dead character and then decide how the ragdoll should look (as in missing
/// body parts will match between the original character and the ragdoll)
//////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class RagdollLogic : MonoBehaviour {
	[HideInInspector]
	public CharacterSetup parent;

	public bool usePooling;
	public bool isUpperBody; //is this ragdoll just the upperbody 
	public bool isSoloMesh; //does this ragdoll only consists of one body part? if so you don't have to identify any of the below objects
	[HideInInspector]
	public bool legOff = false;

	//mesh body parts
	public GameObject[] head;
	public GameObject[] rightHand;
	public GameObject[] leftHand;
	public GameObject[] rightLeg;
	public GameObject[] leftLeg;
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

	public Collider[] headColliders;
	//public Collider rightHandCollider;
	//public Collider leftHandCollider;
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

	public GameObject headBlood;
	public GameObject rightHandBlood;
	public GameObject leftHandBlood;
	public GameObject rightLegBlood;
	public GameObject leftLegBlood;
	public GameObject rightUpperBlood;
	public GameObject leftUpperBlood;
	public GameObject rightForArmBlood;
	public GameObject leftForArmBlood;
	public GameObject upperBodyBlood;
	public GameObject extra1Blood;
	public GameObject extra2Blood;
	public GameObject extra3Blood;
	public GameObject extra4Blood;

	void OnEnable() {
		if (usePooling) {
			if (!isSoloMesh){
				if (parent.headOff && head != null) {
					foreach (GameObject headMesh in head) {
						headMesh.SetActive(false);

						if(headBlood != null) {
							headBlood.SetActive(true);
						}
						foreach (Collider headCollider in headColliders) {
							if (!isUpperBody) {
								headCollider.enabled = false;
							}
						}
					}
					
				} else if (!parent.headOff && head != null) {
					foreach (GameObject headMesh in head) {
						headMesh.SetActive(true);

						if(headBlood != null) {
							headBlood.SetActive(false);
						}
						foreach (Collider headCollider in headColliders) {
							if (!isUpperBody) {
								headCollider.enabled = true;
							}
						}
					}




				}
				
				if (parent.rightHandOff && rightHand != null ) {
					foreach (GameObject rightHandMesh in rightHand) {
						rightHandMesh.SetActive(false);
						
						if(rightHandBlood != null && !parent.rightForArmOff && ! parent.rightUpperOff) {
							rightHandBlood.SetActive(true);
						}
						
					}
					
				} else if (!parent.rightHandOff && rightHand != null) {
					foreach (GameObject rightHandMesh in rightHand) {
						rightHandMesh.SetActive(true);
						
						if(rightHandBlood != null) {
							rightHandBlood.SetActive(false);
						}
						
					}
				}
				
				if (parent.leftHandOff && leftHand != null) {
					foreach (GameObject leftHandMesh in leftHand) {
						leftHandMesh.SetActive(false);
						
						if(leftHandBlood != null && !parent.leftForArmOff && !parent.leftUpperOff) {
							leftHandBlood.SetActive(true);
						}
						
					}
					
				} else if (!parent.leftHandOff && leftHand != null) {
					foreach (GameObject leftHandMesh in leftHand) {
						leftHandMesh.SetActive(true);
						
						if(leftHandBlood != null) {
							leftHandBlood.SetActive(false);
						}
						
					}
				}
				
				if(parent.rightLegOff && rightLeg != null ) {
					foreach (GameObject rightLegMesh in rightLeg) {
						rightLegMesh.SetActive(false);
						
						if(rightLegBlood != null) {
							rightLegBlood.SetActive(true);
						}
						foreach(Collider rightLegCollider in rightLegColliders) {
							if (!isUpperBody) {
								rightLegCollider.enabled = false;
							}
						}
					}
					
				} else if (!parent.rightLegOff && rightLeg != null) {
					foreach (GameObject rightLegMesh in rightLeg) {
						rightLegMesh.SetActive(true);
						
						if(rightLegBlood != null) {
							rightLegBlood.SetActive(false);
						}
						foreach(Collider rightLegCollider in rightLegColliders) {
							if (!isUpperBody) {
								rightLegCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.leftLegOff && leftLeg != null ) {
					foreach (GameObject leftLegMesh in leftLeg) {
						leftLegMesh.SetActive(false);
						
						if(leftLegBlood != null) {
							leftLegBlood.SetActive(true);
						}
						foreach (Collider leftLegCollider in leftLegColliders) {
							if (!isUpperBody) {
								leftLegCollider.enabled = false;
							}
						}
					}
				} else if (!parent.leftLegOff && leftLeg != null) {
					foreach (GameObject leftLegMesh in leftLeg) {
						leftLegMesh.SetActive(true);
						
						if(leftLegBlood != null) {
							leftLegBlood.SetActive(false);
						}
						foreach (Collider leftLegCollider in leftLegColliders) {
							if (!isUpperBody) {
								leftLegCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.rightUpperOff && rightUpperArm != null) {
					foreach (GameObject rightUpper in rightUpperArm) {
						rightUpper.SetActive(false);
						if(rightUpperBlood != null) {
							rightUpperBlood.SetActive(true);
						}
						foreach (Collider rightUpperArmCollider in rightUpperArmColliders) {
							if (!isUpperBody) {
								rightUpperArmCollider.enabled = false;
							}
						}
					}
				} else if (!parent.rightUpperOff && rightUpperArm != null) {
					foreach (GameObject rightUpper in rightUpperArm) {
						rightUpper.SetActive(true);
						if(rightUpperBlood != null) {
							rightUpperBlood.SetActive(false);
						}
						foreach (Collider rightUpperArmCollider in rightUpperArmColliders) {
							if (!isUpperBody) {
								rightUpperArmCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.leftUpperOff && leftUpperArm != null ) {
					foreach(GameObject leftUpper in leftUpperArm) {
						leftUpper.SetActive(false);
						if(leftUpperBlood != null) {
							leftUpperBlood.SetActive(true);
						}
						foreach (Collider leftUpperArmCollider in leftUpperArmColliders) {
							if (!isUpperBody) {
								leftUpperArmCollider.enabled = false;
							}
						}
					}
				} else if (!parent.leftUpperOff && leftUpperArm != null) {
					foreach(GameObject leftUpper in leftUpperArm) {
						leftUpper.SetActive(true);
						if(leftUpperBlood != null) {
							leftUpperBlood.SetActive(false);
						}
						foreach (Collider leftUpperArmCollider in leftUpperArmColliders) {
							if (!isUpperBody) {
								leftUpperArmCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.rightForArmOff && rightForArm != null ) {
					foreach (GameObject rightLowerArm in rightForArm) {
						rightLowerArm.SetActive(false);
						if(rightForArmBlood != null && !parent.rightUpperOff) {
							rightForArmBlood.SetActive(true);
						}
						foreach (Collider rightForArmCollider in rightForArmColliders) {
							if (!isUpperBody) {
								rightForArmCollider.enabled = false;
							}
						}
					}
				} else if (!parent.rightForArmOff && rightForArm != null) {
					foreach (GameObject rightLowerArm in rightForArm) {
						rightLowerArm.SetActive(true);
						if(rightForArmBlood != null) {
							rightForArmBlood.SetActive(false);
						}
						foreach (Collider rightForArmCollider in rightForArmColliders) {
							if (!isUpperBody) {
								rightForArmCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.leftForArmOff && leftForArm != null ) {
					foreach (GameObject leftLowerArm in leftForArm) {
						leftLowerArm.SetActive(false);
						if(leftForArmBlood != null && !parent.leftUpperOff) {
							leftForArmBlood.SetActive(true);
						}
						foreach (Collider leftForArmCollider in leftForArmColliders) {
							if (!isUpperBody) {
								leftForArmCollider.enabled = false;
							}
						}
					}
				} else if (!parent.leftForArmOff && leftForArm != null) {
					foreach (GameObject leftLowerArm in leftForArm) {
						leftLowerArm.SetActive(true);
						if(leftForArmBlood != null) {
							leftForArmBlood.SetActive(false);
						}
						foreach (Collider leftForArmCollider in leftForArmColliders) {
							if (!isUpperBody) {
								leftForArmCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.upperBodyOff) {
					if (!isUpperBody & upperBody != null) {
						if(upperBodyBlood != null) {
							upperBodyBlood.SetActive(true);
						}
						foreach (GameObject upper in upperBody) {
							upper.SetActive(false);

							foreach(Collider upperBodyCollider in upperBodyColliders) {
								upperBodyCollider.enabled = false;
							}
						}
					}
					
				} else if (!parent.upperBodyOff) {
					if (!isUpperBody & upperBody != null) {
						if(upperBodyBlood != null) {
							upperBodyBlood.SetActive(false);
						}
						foreach (GameObject upper in upperBody) {
							upper.SetActive(true);

							foreach(Collider upperBodyCollider in upperBodyColliders) {
								upperBodyCollider.enabled = true;
							}
						}
					}
				}
				
				if (parent.lowerBodyOff && lowerBody !=null) {
					foreach (GameObject lower in lowerBody) {
						lower.SetActive(false);
						foreach (Collider lowerBodyCollider in lowerBodyColliders) {
							lowerBodyCollider.enabled = false;
						}
					}
				}
			}
			
			if (parent.extra1Off && extra1 != null ) {
				foreach (GameObject extra1Mesh in extra1) {
					extra1Mesh.SetActive(false);
					if(extra1Blood != null) {
						extra1Blood.SetActive(true);
					}
					foreach (Collider extra1Collider in extra1Colliders) {
						if (!isUpperBody) {
							extra1Collider.enabled = false;
						}
					}
				}
			}
			
			if (parent.extra2Off && extra2 != null ) {
				foreach (GameObject extra2Mesh in extra2) {
					extra2Mesh.SetActive(false);
					if(extra2Blood != null) {
						extra2Blood.SetActive(true);
					}
					foreach (Collider extra2Collider in extra2Colliders) {
						if (!isUpperBody) {
							extra2Collider.enabled = false;
						}
					}
				}
			}
			
			if (parent.extra3Off && extra3 != null ) {
				foreach (GameObject extra3Mesh in extra3) {
					extra3Mesh.SetActive(false);
					if(extra3Blood != null) {
						extra3Blood.SetActive(true);
					}
					foreach (Collider extra3Collider in extra3Colliders) {
						if (!isUpperBody) {
							extra3Collider.enabled = false;
						}
					}
				}
			}
			
			if (parent.extra4Off && extra4 != null ) {
				foreach (GameObject extra4Mesh in extra4) {
					extra4Mesh.SetActive(false);
					if(extra4Blood != null) {
						extra4Blood.SetActive(true);
					}
					foreach (Collider extra4Collider in extra4Colliders) {
						if (!isUpperBody) {
							extra4Collider.enabled = false;
						}
					}
				}
			}
			
			if (parent.destroyRagdolls) {
				StartCoroutine(DestroyRagdolls());
				
			}
		}
	}

	void Start () {
		if(parent.rightLegOff || parent.leftLegOff) legOff = true;
		if (!usePooling) {
			if(parent.destroyRagdolls) StartCoroutine(DestroyRagdolls ());
			if (!isSoloMesh){
				if (parent.headOff && head != null) {
					foreach (GameObject headMesh in head) {
						headMesh.SetActive(false);

						if(headBlood != null) {
							headBlood.SetActive(true);
						}
						foreach (Collider headCollider in headColliders) {
							if (!isUpperBody) {
								headCollider.enabled = false;
							}
						}
					}

				}

				if (parent.rightHandOff && rightHand != null ) {
					foreach (GameObject rightHandMesh in rightHand) {
						rightHandMesh.SetActive(false);

						if(rightHandBlood != null && !parent.rightForArmOff && !parent.rightUpperOff) {
							rightHandBlood.SetActive(true);
						}

					}

				}

				if (parent.leftHandOff && leftHand != null) {
					foreach (GameObject leftHandMesh in leftHand) {
						leftHandMesh.SetActive(false);
					
						if(leftHandBlood != null && !parent.leftForArmOff && !parent.leftUpperOff) {
							leftHandBlood.SetActive(true);
						}
					
					}

				}

				if(parent.rightLegOff) {
					foreach (GameObject rightLegMesh in rightLeg) {
						rightLegMesh.SetActive(false);

						if(rightLegBlood != null) {
							rightLegBlood.SetActive(true);
						}
						foreach(Collider rightLegCollider in rightLegColliders) {
							if (!isUpperBody) {
							rightLegCollider.enabled = false;
							}
						}
					}

				}

				if (parent.leftLegOff) {
					foreach (GameObject leftLegMesh in leftLeg) {
						leftLegMesh.SetActive(false);
					
						if(leftLegBlood != null) {
							leftLegBlood.SetActive(true);
						}
						foreach (Collider leftLegCollider in leftLegColliders) {
							if (!isUpperBody) {
							leftLegCollider.enabled = false;
							}
						}
					}
				}

				if (parent.rightUpperOff && rightUpperArm != null) {
					foreach (GameObject rightUpper in rightUpperArm) {
						rightUpper.SetActive(false);
						if(rightUpperBlood != null) {
							rightUpperBlood.SetActive(true);
						}
						foreach (Collider rightUpperArmCollider in rightUpperArmColliders) {
							if (!isUpperBody) {
								rightUpperArmCollider.enabled = false;
							}
						}
					}
				}

				if (parent.leftUpperOff && leftUpperArm != null ) {
					foreach(GameObject leftUpper in leftUpperArm) {
						leftUpper.SetActive(false);
						if(leftUpperBlood != null) {
							leftUpperBlood.SetActive(true);
						}
						foreach (Collider leftUpperArmCollider in leftUpperArmColliders) {
							if (!isUpperBody) {
							leftUpperArmCollider.enabled = false;
							}
						}
					}
				}

				if (parent.rightForArmOff && rightForArm != null ) {
					foreach (GameObject rightLowerArm in rightForArm) {
						rightLowerArm.SetActive(false);
						if(rightForArmBlood != null && !parent.rightUpperOff) {
							rightForArmBlood.SetActive(true);
						}
						foreach (Collider rightForArmCollider in rightForArmColliders) {
							if (!isUpperBody) {
								rightForArmCollider.enabled = false;
							}
						}
					}
				}

				if (parent.leftForArmOff && leftForArm != null ) {
					foreach (GameObject leftLowerArm in leftForArm) {
						leftLowerArm.SetActive(false);
						if(leftForArmBlood != null && !parent.leftUpperOff) {
						leftForArmBlood.SetActive(true);
						}
						foreach (Collider leftForArmCollider in leftForArmColliders) {
							if (!isUpperBody) {
							leftForArmCollider.enabled = false;
							}
						}
					}
				}

				if (parent.upperBodyOff) {
					if (!isUpperBody & upperBody != null) {
						if(upperBodyBlood != null) {
						upperBodyBlood.SetActive(true);
						}
						foreach (GameObject upper in upperBody) {
							upper.SetActive(false);

							foreach(Collider upperBodyCollider in upperBodyColliders) {
								upperBodyCollider.enabled = false;
							}
						}
					}

				}

				if (parent.lowerBodyOff && lowerBody !=null) {
					foreach (GameObject lower in lowerBody) {
						lower.SetActive(false);
						foreach (Collider lowerBodyCollider in lowerBodyColliders) {
							lowerBodyCollider.enabled = false;
						}
					}
				}

				if (parent.extra1Off && extra1 != null ) {
					foreach (GameObject extra1Mesh in extra1) {
						extra1Mesh.SetActive(false);
						if(extra1Blood != null) {
							extra1Blood.SetActive(true);
						}
						foreach (Collider extra1Collider in extra1Colliders) {
							if (!isUpperBody) {
								extra1Collider.enabled = false;
							}
						}
					}
				} 

				if (parent.extra2Off && extra2 != null ) {
					foreach (GameObject extra2Mesh in extra2) {
						extra2Mesh.SetActive(false);
						if(extra2Blood != null) {
							extra2Blood.SetActive(true);
						}
						foreach (Collider extra2Collider in extra2Colliders) {
							if (!isUpperBody) {
							extra2Collider.enabled = false;
							}
						}
					}
				} 

				if (parent.extra3Off && extra3 != null ) {
					foreach (GameObject extra3Mesh in extra3) {
						extra3Mesh.SetActive(false);
						if(extra3Blood != null) {
							extra3Blood.SetActive(true);
						}
						foreach (Collider extra3Collider in extra3Colliders) {
							if (!isUpperBody) {
								extra3Collider.enabled = false;
							}
						}
					}
				} 

				if (parent.extra4Off && extra4 != null ) {
					foreach (GameObject extra4Mesh in extra4) {
						extra4Mesh.SetActive(false);
						if(extra4Blood != null) {
							extra4Blood.SetActive(true);
						}
						foreach (Collider extra4Collider in extra4Colliders) {
							if (!isUpperBody) {
								extra4Collider.enabled = false;
							}
						}
					}
				} 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//This gives time before the ragdolls are destroyed to do functions on the ragdolls or just display them gloriously
	IEnumerator DestroyRagdolls () {
		yield return new WaitForSeconds(parent.bodyStayTime);
			Destroy(this.gameObject,0.01f);
	}
}
