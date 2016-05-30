using UnityEngine;
using System.Collections;

public class LimbBloodFX : MonoBehaviour, IBloodyMessEventHandler {
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



	public void OnLimbDeath(int limbID, GameObject spawnedLimb, GameObject removedLimb, Vector3 attackerPosition, Vector3 attackerDirection)
	{
		switch(removedLimb.tag) 
		{
		case "Head":
			if (headBlood != null) headBlood.SetActive(true);
			break;
			
		case "RightHand":
			if (rightHandBlood != null) rightHandBlood.SetActive(true);
			break;
			
		case "LeftHand":
			if (leftHandBlood != null) leftHandBlood.SetActive(true);
			break;
			
		case "RightLeg":

			if (rightLegBlood != null) rightLegBlood.SetActive(true);
			break;
			
		case "LeftLeg":
			if (leftLegBlood != null) leftLegBlood.SetActive(true);
			break;
			
		case "RightUpper":
			if (rightUpperBlood != null) 
			{
				rightUpperBlood.SetActive(true);
				rightForArmBlood.SetActive(false);
				rightHandBlood.SetActive(false);
			}
			break;
			
		case "LeftUpper":
			if (leftUpperBlood != null) 
			{
				leftUpperBlood.SetActive(true);
				leftForArmBlood.SetActive(false);
				leftHandBlood.SetActive(false);
			}
			break;
			
		case "RightForeArm":
			if (rightForArmBlood != null) 
			{
				rightForArmBlood.SetActive(true);
				rightHandBlood.SetActive(false);
			}
			break;
			
			
			
		case "LeftForeArm":
			if (leftForArmBlood != null)
			{
				leftForArmBlood.SetActive(true);
				leftHandBlood.SetActive(false);
			}

			break;
			
		case "UpperBody":
			if (upperBodyBlood != null) upperBodyBlood.SetActive(true);
			break;
			
		
			
		case "Extra1":
			if (extra1Blood != null) extra1Blood.SetActive(true);
			break;
			
		case "Extra2":
			if (extra2Blood != null) extra2Blood.SetActive(true);
			break;
			
		case "Extra3":
			if (extra3Blood != null) extra3Blood.SetActive(true);
			break;
			
		case "Extra4":
			if (extra4Blood != null) extra4Blood.SetActive(true);
			break;



		}
	}
	public void OnDeath(Transform ragdoll)
	{

	}

}
