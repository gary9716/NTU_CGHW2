using UnityEngine;
using System.Collections;

public class DestroyLimb : MonoBehaviour {

	public float limbDestroyTimer = 15.0f;

	// Use this for initialization
	void Start () {

		Destroy (this.gameObject, limbDestroyTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
