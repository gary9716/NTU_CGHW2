using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	private Animator anim;
	private Vector3 moveDirection;
	public float turnSpeed = 10.0f;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		moveDirection = new Vector3(h,0.0f,z);

		if (h >= 0.5 || z >= 0.5 || h <= -0.5 || z<= -0.5) {
			anim.SetFloat("Speed", 1);
			Quaternion lookRot = Quaternion.LookRotation(moveDirection - transform.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
		} else {
			anim.SetFloat("Speed",0);
		}


	}
}
