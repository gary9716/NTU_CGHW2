using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MineLevelManager : MonoBehaviour {
	public GameObject deadObj;
	public GameObject winObj;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Lose() {
		deadObj.SetActive(true);
		StartCoroutine (RestartLevel());

	}


	public void Win() {
		winObj.SetActive(true);
		StartCoroutine (RestartLevel());
	}

	IEnumerator RestartLevel() {
		yield return new WaitForSeconds(3.0f);

		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu() {
		Application.LoadLevel("MainMenu");
	}
}
